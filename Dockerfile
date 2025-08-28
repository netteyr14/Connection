# Use a lightweight Python image (slim variant) as the base
# This provides Python 3.11 without unnecessary extras, keeping the image small
FROM python:3.11-slim

# Set the working directory inside the container
# All subsequent commands will be run from /app
WORKDIR /app

# -----------------------------------------------
# Install Python dependencies
# -----------------------------------------------

# Copy only the requirements.txt first to leverage Docker layer caching
COPY SM_API_N_WEB/requirements.txt .
COPY SM_API_N_WEB/templates ./templates
COPY SM_API_N_WEB/static ./static

# Install all Python packages listed in requirements.txt
# --no-cache-dir prevents pip from storing the cache inside the image (saves space)
RUN pip install --no-cache-dir -r requirements.txt

# -----------------------------------------------
# Copy Flask app and Waitress runner
# -----------------------------------------------

# db_routing_api.py -> your Flask application
COPY SM_API_N_WEB/db_routing_api.py .
# my_waitress.py -> entrypoint script that runs Flask app using Waitress
COPY SM_API_N_WEB/my_waitress.py .

# -----------------------------------------------
# Install nginx, supervisord, and netcat
# -----------------------------------------------

# Update package lists, install required packages, and clean apt cache
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
        nginx \
        supervisor \
        netcat-openbsd \
        apt-utils && \
    rm -rf /var/lib/apt/lists/*

# -----------------------------------------------
# Copy nginx configuration
# -----------------------------------------------

# Replace default nginx.conf with your custom configuration
# This allows nginx to proxy requests to Waitress
COPY SM_API_N_WEB/nginx-1.28.0/conf/nginx.conf /etc/nginx/nginx.conf

# -----------------------------------------------
# Copy supervisord configuration
# -----------------------------------------------

# supervisord.conf defines how to run multiple processes (nginx + Waitress)
# Copy it to supervisor's config directory
COPY supervisord.conf /etc/supervisor/conf.d/supervisord.conf

# -----------------------------------------------
# Expose port 8080 for external access
# -----------------------------------------------

# Render will map this port to the public URL
EXPOSE 8080

# -----------------------------------------------
# Start supervisord as the main process
# -----------------------------------------------

# -n flag tells supervisord to run in the foreground (required for Docker)
# supervisord starts and monitors both Waitress and nginx inside the container
CMD ["/usr/bin/supervisord", "-c", "/etc/supervisor/conf.d/supervisord.conf", "-n"]
