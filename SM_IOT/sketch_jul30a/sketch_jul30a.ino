#include <WiFi.h>
#include <HTTPClient.h>
#include <SPI.h>
#include <MFRC522.h>

// WiFi credentials
const char* ssid = "4G-Isorena wifi";
const char* password = "Arvin06072003";

// Flask server IP and route
const char* serverName = "http://192.168.1.7:8080/api/rfid";

// RFID pins
#define RST_PIN 4
#define SDA_PIN 21

MFRC522 rfid(SDA_PIN, RST_PIN);
String CardNum = "";
int lab = 1;

unsigned long lastCardTime = 0;
unsigned long lastRfidReset = 0;
unsigned long lastWiFiCheck = 0;

// --- Ensure WiFi is always connected ---
void ensureWiFiConnected() {
  if (WiFi.status() != WL_CONNECTED) {
    Serial.println("Reconnecting WiFi...");
    WiFi.disconnect();
    WiFi.begin(ssid, password);

    unsigned long startAttempt = millis();
    while (WiFi.status() != WL_CONNECTED && millis() - startAttempt < 10000) {
      delay(500);
      Serial.print(".");
    }
    if (WiFi.status() == WL_CONNECTED) {
      Serial.println("\nWiFi reconnected.");
    } else {
      Serial.println("\nWiFi reconnect failed.");
    }
  }
}

bool getID() {
  if (!rfid.PICC_IsNewCardPresent() || !rfid.PICC_ReadCardSerial()) {
    return false;
  }

  CardNum = "";
  for (byte i = 0; i < 4; i++) {
    if (rfid.uid.uidByte[i] < 0x10) {
    CardNum.concat("0");  // add leading zero if less than 16
    }
    CardNum.concat(String(rfid.uid.uidByte[i], HEX));
  }
  CardNum.toUpperCase();
  rfid.PICC_HaltA();

  lastCardTime = millis();  // update last card detection
  return true;
}

void sendToServer(String cardUID, int labID) {
  ensureWiFiConnected();  // make sure WiFi is alive

  if (WiFi.status() == WL_CONNECTED) {
    HTTPClient http;
    http.begin(serverName);
    http.addHeader("Content-Type", "application/json");

    String jsonPayload = "{\"uid\":\"" + cardUID + "\", \"lab\":" + String(labID) + "}";
    int httpResponseCode = http.POST(jsonPayload);

    if (httpResponseCode > 0) {
      Serial.println("POST success: " + String(httpResponseCode));
      String response = http.getString();
      Serial.println("Response: " + response);
    } else {
      Serial.print("Error on sending POST: ");
      Serial.println(httpResponseCode);
    }

    http.end();
  } else {
    Serial.println("WiFi still disconnected, cannot send.");
  }
}

void setup() {
  Serial.begin(115200);
  SPI.begin();  // SCK=18, MISO=19, MOSI=23
  rfid.PCD_Init();

  Serial.print("Connecting to WiFi");
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("\nWiFi connected.");
  Serial.println("ESP32 ready.");
}

void loop() {
  // Check for RFID card
  if (getID()) {
    Serial.println("Lab Number: " + String(lab));
    Serial.println("Card UID: " + CardNum);
    sendToServer(CardNum, lab);
    delay(1000);
  }

  // Re-init RFID if idle for 30s
  if (millis() - lastCardTime > 30000 && millis() - lastRfidReset > 30000) {
    Serial.println("Reinitializing RFID reader...");
    rfid.PCD_Init();
    lastRfidReset = millis();
  }

  // Check WiFi every 10s
  if (millis() - lastWiFiCheck > 10000) {
    ensureWiFiConnected();
    lastWiFiCheck = millis();
  }
}
