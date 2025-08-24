from waitress import serve
from db_routing_api import app
import os

if __name__ == '__main__':
    print("[INFO] Starting the server...")
    # print("@127.0.0.1:5000 or 192.168.1.7:5000")
    my_port = int(os.environ.get('PORT', 5000))
    serve(app, host='0.0.0.0', port=my_port, thread=8)
