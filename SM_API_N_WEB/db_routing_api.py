from flask import Flask, request, jsonify, render_template
from datetime import datetime
import mysql.connector
from mysql.connector import Error, pooling
import os
# import time
import warnings
warnings.filterwarnings("ignore", category=DeprecationWarning)

app = Flask(__name__)

db0 = {
    'host': os.environ.get('DB_HOST'),                   # ngrok host
    'user': os.environ.get('DB_USER'),                                # root or MySQL user
    'password': os.environ.get('DB_PASS'),                     # database password
    'database': os.environ.get('DB'),                      # database name
    'port': os.environ.get('DB_PORT'),
    'ssl_ca': os.environ.get('AIVEN_CA_CERT')# default MySQL port
}
pool = None

def init_db_pool_rfid():
    global pool
    try:
        pool= pooling.MySQLConnectionPool(
            pool_name = "mypool",
            pool_size = 5,
            **db0
        )
        print("[INFO] Database pool created successfully!")
    except Error as e:
        print(f"[ERROR] Database pool creation failed: {e}")


init_db_pool_rfid()
# def connect_to_database_rfid():
#     """Establish a secure connection to the MySQL database."""
#     try:
#         print(f"Connecting to database at {db0['host']} on port {db0['port']}")
#         connection = mysql.connector.connect(**db0)
#         if connection.is_connected():
#             print("Database connection successful!")
#             return connection
#     except Error as e:
#         print(f"Database connection error: {e}")
#     return None

# db1 = {
#     'host': 'localhost',
#     'user': 'root',               # root or MySQL user
#     'password': 'Ambin123456123456', # database password
#     'database': 'dht11',  # database name
#     'port': 3306                 # default MySQL port
# }

# def connect_to_database_dht11():
#     """Establish a secure connection to the MySQL database."""
#     try:
#         print(f"Connecting to database at {db1['host']} on port {db1['port']}")
#         connection = mysql.connector.connect(**db1)
#         if connection.is_connected():
#             print("Database connection successful!")
#             return connection
#     except Error as e:
#         print(f"Database connection error: {e}")
#     return None

# API route for frontend JS
def fetch_all(query, params=None):
    conn = pool.get_connection()
    cursor = conn.cursor(dictionary=True)

    try:
        cursor.execute(query, params or ())
        return cursor.fetchall()
    finally:
        cursor.close()
        conn.close()

@app.route('/api/data/students')
def get_data_logs_stud():
    # Get only today's records #the table is tbl_views_logs_today_stud(VIEWS). Also this view is already modified to use where clause
    # to get only today's records
    sql = "SELECT * FROM tbl_views_logs_today_stud ORDER BY logs_date DESC"
    data = fetch_all(sql)
    return jsonify(data)

@app.route('/api/data/professors')
def get_data_logs_prof():
    # Get only today's records #the table is tbl_views_logs_today_prof(VIEWS). Also this view is already modified to use where clause
    # to get only today's records
    sql = "SELECT * FROM tbl_views_logs_today_prof ORDER BY logs_date DESC"
    data = fetch_all(sql)
    return jsonify(data)

@app.route('/search/students', methods=['POST'])
def search_students():
    data = request.get_json()
    query = data.get('query', '')

    conn = pool.get_connection()
    cursor = conn.cursor(dictionary=True)
    print("Query string from frontend:", query)

    like_query = f"%{query}%"
    
    cursor.execute("""
        SELECT * FROM tbl_views_logs_today_stud
        WHERE school_id LIKE %s
           OR fname LIKE %s
           OR lname LIKE %s
           OR lab_name LIKE %s
           OR TIME(logs_date) LIKE %s
        ORDER BY logs_date DESC
    """, (like_query, like_query, like_query, like_query, like_query))
    
    results = cursor.fetchall()
    print("Query for SQL LIKE:", query)
    print("Results found:", len(results))
    cursor.close()
    conn.close()

    return jsonify(results)

@app.route('/search/professors', methods=['POST'])
def search_professors():
    data = request.get_json()
    query = data.get('query', '')

    conn = pool.get_connection()
    cursor = conn.cursor(dictionary=True)
    print("Query string from frontend:", query)

    like_query = f"%{query}%"
    
    cursor.execute("""
        SELECT * FROM tbl_views_logs_today_prof
        WHERE school_id LIKE %s
           OR fname LIKE %s
           OR lname LIKE %s
           OR lab_name LIKE %s
           OR TIME(logs_date) LIKE %s
        ORDER BY logs_date DESC
    """, (like_query, like_query, like_query, like_query, like_query))
    
    results = cursor.fetchall()
    print("Query for SQL LIKE:", query)
    print("Results found:", len(results))
    cursor.close()
    conn.close()

    return jsonify(results)

# @app.route('/api/nodes/<path:node>/dates/<path:date>')
# def get_weather_by_node_and_date(node, date):
#     connection = connect_to_database_dht11()
#     cursor = connection.cursor(dictionary=True)
#     cursor.execute("""
#         SELECT timestamp, temperature, humidity, dew_point, heat_index, cloud_formation 
#         FROM weather_data 
#         WHERE node_name = %s AND DATE(timestamp) = %s
#         ORDER BY timestamp DESC
#         LIMIT 1
#     """, (node, date))
    
#     row = cursor.fetchone()
#     cursor.close()
#     connection.close()

#     if row:
#         return jsonify(row)  # Just a single record
#     else:
#         return jsonify({"error": "No data found"}), 404


# @app.route('/api/nodes')
# def get_nodes():
#     connection = connect_to_database_dht11()
#     cursor = connection.cursor(dictionary=True)  # Get results as dicts
#     cursor.execute("SELECT DISTINCT node_name FROM weather_data")
#     data = cursor.fetchall()
#     cursor.close()
#     connection.close()
#     return jsonify(data)

# @app.route('/api/nodes/<path:node>/dates')
# def get_dht11_timestamp(node):
#     connection = connect_to_database_dht11()
#     cursor = connection.cursor()
    
#     # Get DISTINCT dates (not timestamps) for the given node
#     cursor.execute("SELECT DISTINCT DATE(timestamp) AS date FROM weather_data WHERE node_name = %s ORDER BY date DESC", (node,))
#     data = [row[0].strftime('%Y-%m-%d') for row in cursor.fetchall()]
    
#     cursor.close()
#     connection.close()
    
#     return jsonify(data)

#Main Pages (Serves HTML Web Pages)
@app.route('/')
def index():
    return render_template('index1.html')  # Make sure your HTML is named index.html and inside a /templates folder. Flask can use PHP

@app.route('/students')
def students():
    return render_template('students.html')  # Must be in /templates folder

@app.route('/professors')
def professors():
    return render_template('professors.html')  # Must be in /templates folder

#RFID POST Routes
@app.route('/api/rfid', methods=['POST'])
def receive_rfid_uid():
    data = request.get_json()
    uid = data.get('uid', 'unknown')
    lab = data.get('lab', 'not specified')
    print(f"Received UID: {uid}")
    print(f"Received Lab: {lab}")
    try:
        connection = connect_to_database_rfid()
        cursor = connection.cursor() #use the dictionary=True as parameters if you want to get results as dicts instead of typical tuples which is access as indices
        
        # 1. Check if UID is registered
        cursor.execute("SELECT rfid_uid FROM tbl_rfid WHERE rfid_uid = %s", (uid,))
        result = cursor.fetchone()
        if result is None:
            print("[INFO] UID not registered.\n")
            return jsonify({'status': 'error', 'message': 'UID not registered'}), 404

        print("[ACCESS] UID recognized. Access granted.")

        # 2. Check if the user already scanned today in the same lab
        cursor.execute("""
            SELECT logs_lab, logs_date
            FROM tbl_log
            WHERE logs_rfid = %s AND DATE(logs_date) = CURDATE()
            ORDER BY logs_date DESC
            LIMIT 1
        """, (uid,))
        row = cursor.fetchone()

        if row and row[0] == int(lab):
            print("[INFO] UID already scanned today in the same lab.\n")
            return jsonify({'status': 'success','message': 'UID Already Scanned.','received_uid': uid,'received_lab': lab}), 200
        else:
            # 3. Log the scan
            cursor.execute(
                "INSERT INTO tbl_log (logs_rfid, logs_lab) VALUES (%s, %s)",
                (uid, lab)
            )
            connection.commit()
            print("[INFO] Scan logged successfully.\n")
            return jsonify({'status': 'success','message': 'UID Scanned.','received_uid': uid,'received_lab': lab}), 200

    except Exception as e:
        print("[ERROR]", str(e))
        return jsonify({'status': 'error', 'message': str(e)}), 500

    finally:
        cursor.close()
        connection.close()

#Registration Routes
@app.route('/api/reg_table', methods=['GET'])
def get_reg_table():
    try:
        search = request.args.get("search", "")

        connection = connect_to_database_rfid()
        cursor = connection.cursor(dictionary=True)

        if search:
            query = "select * from tbl_views_registration where id like %s or fname like %s or lname like %s or id_lvl like %s or school_id like %s or rfid_uid like %s"
            params = (f"%{search}%", f"%{search}%", f"%{search}%", f"%{search}%", f"%{search}%", f"%{search}%")
            cursor.execute(query, params)
        else:
            query = "SELECT * FROM tbl_views_registration"
            cursor.execute(query)

        rows = cursor.fetchall()
        return jsonify(rows)
    
    except Exception as e:
        print("[ERROR]", str(e))
        return jsonify({'status': 'error', 'message': str(e)}), 500
    finally:
        cursor.close()
        connection.close()

@app.route('/api/insert', methods=['POST'])
def insert_reg():
    data = request.get_json()
    sql = data.get('Query', '')
    sid = data.get('SID', '')
    fname = data.get('FirstName', '')
    lname = data.get('LastName', '')
    ut = data.get('UserType', '')
    rfid = data.get('RFID', '')

    try:
        connection = connect_to_database_rfid()
        cursor = connection.cursor()
        cursor.execute(sql, (sid, fname, lname, ut, rfid))
        connection.commit()
            
        return jsonify({'status': 'success', 'message': 'Record inserted successfully'}), 200
    except Exception as e:
        print("[ERROR]", str(e))
        return jsonify({'status': 'error', 'message': str(e)}), 500
    finally:
        cursor.close()
        connection.close()

@app.route('/api/update', methods=['PUT'])
def update_reg():
    data = request.get_json()
    sql = data.get('Query', '')
    sid = data.get('SID', '')
    fname = data.get('FirstName', '')
    lname = data.get('LastName', '')
    ut = data.get('UserType', '')
    rfid = data.get('RFID', '')
    id = data.get('ID', '')

    try:
        connection = connect_to_database_rfid()
        cursor = connection.cursor()
        cursor.execute(sql, (sid, fname, lname, ut, rfid, id))
        connection.commit()
            
        return jsonify({'status': 'success', 'message': 'Record inserted successfully'}), 200
    except Exception as e:
        print("[ERROR]", str(e))
        return jsonify({'status': 'error', 'message': str(e)}), 500
    finally:
        cursor.close()
        connection.close()

@app.route('/api/delete', methods=['DELETE'])
def delete_reg():
    data = request.get_json()
    sql = data.get('Query', '')
    id = data.get('ID', '')

    try:
        connection = connect_to_database_rfid()
        cursor = connection.cursor()
        cursor.execute(sql, (id,))
        connection.commit()
            
        return jsonify({'status': 'success', 'message': 'Record inserted successfully'}), 200
    except Exception as e:
        print("[ERROR]", str(e))
        return jsonify({'status': 'error', 'message': str(e)}), 500
    finally:
        cursor.close()
        connection.close()
    
#Main
# if __name__ == '__main__':
#     try:
#         app.run(debug=True, host='0.0.0.0')
#     finally:
#         if os.environ.get('WERKZEUG_RUN_MAIN') == 'true':
#             print("\n[INFO] Exiting...")


## uncomment the code above for testing purposes
    
