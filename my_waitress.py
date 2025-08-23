from waitress import serve
from db_routing_api import app

if __name__ == '__main__':
    print("[INFO] Starting the server...")
    print("@127.0.0.1:5000 or 192.168.1.7:5000")
    serve(app, host='localhost', port=5000)
