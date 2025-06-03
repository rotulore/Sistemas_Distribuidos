FROM python:3.9-slim

# Directorio de trabajo
WORKDIR /app

# Instala dependencias
COPY requirements.txt .
RUN pip install --no-cache-dir -r requirements.txt

# Copia el código fuente y genera los stubs de gRPC
COPY . .
RUN python -m grpc_tools.protoc -I. --python_out=. --grpc_python_out=. trainer.proto

# Expone el puerto gRPC
EXPOSE 50051

# Comando para iniciar el servidor
CMD ["python", "server.py"]