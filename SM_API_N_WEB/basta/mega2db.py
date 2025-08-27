import serial
import mysql.connector
from datetime import datetime
import time

# Connect to the database
db = mysql.connector.connect(
    host="192.168.1.7",
    user="guest_mysql",
    password="Ambin123456_123456",
    database="refined_rfid"
)
cursor = db.cursor()

# Connect to serial port
ser = serial.Serial("COM4", 9600)
print("[INFO] Connected to Serial")

current_lab_id = None  # Stores the current lab number from Arduino

def check_rfid(uid, lab_id):
    if not lab_id:
        print("[ERROR] No lab selected yet. Scan a lab first.")
        return

    # Check if UID exists
    cursor.execute("SELECT rfid FROM rfid_users WHERE rfid = %s", (uid,))
    result = cursor.fetchone()

    if result is None:
        print("[INFO] UID not registered.\n")
        return

    print("[ACCESS] UID recognized. Access granted.")

    # Check if already scanned today
    cursor.execute("SELECT DATE(scanned_at) FROM rfid_logs WHERE uid = %s ORDER BY scanned_at DESC LIMIT 1", (uid,))
    row = cursor.fetchone()

    if row and row[0] == datetime.now().date():
        print("[INFO] UID already scanned today.\n")
    else:
        # Log the scan
        cursor.execute(
            "INSERT INTO rfid_logs (uid, lab_id) VALUES (%s, %s)",
            (uid, lab_id)
        )
        db.commit()
        print("[INFO] Scan logged successfully.\n")

while True:
    try:
        if ser.in_waiting > 0:
            line = ser.readline().decode('utf-8').strip()
            print("[RAW]", line)

            if line[:3] == "lab":
                try:
                    current_lab_id = int(line[3:])
                    print(f"[INFO] Current lab set to: {current_lab_id}\n")
                except ValueError:
                    print("[ERROR] Invalid lab format.\n")

            elif line[:4] == "rfid":
                uid = line[4:]
                check_rfid(uid, current_lab_id)

        time.sleep(0.1)

    except KeyboardInterrupt:
        print("\n[INFO] Exiting...")
        break

# Cleanup
ser.close()
db.close()
