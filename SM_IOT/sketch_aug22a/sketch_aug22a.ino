#include <SPI.h>
#include <MFRC522.h>

#define SS_PIN 53
#define RST_PIN 5

MFRC522 mfrc522(SS_PIN, RST_PIN);

void setup() {
  Serial.begin(9600); // For C# SerialPort
  SPI.begin();
  mfrc522.PCD_Init();
}

void loop() {
  // Look for new cards
  if ( ! mfrc522.PICC_IsNewCardPresent()) {
    return;
  }

  // Select one of the cards
  if ( ! mfrc522.PICC_ReadCardSerial()) {
    return;
  }

  // Print card number as HEX (or you can convert to decimal if needed)
  for (byte i = 0; i < mfrc522.uid.size; i++) {
    Serial.print(mfrc522.uid.uidByte[i] < 0x10 ? "0" : ""); // leading zero
    Serial.print(mfrc522.uid.uidByte[i], HEX);
  }
  Serial.println();

  delay(500); // Avoid repeated reads
}
