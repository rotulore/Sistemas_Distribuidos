import grpc
from concurrent import futures
import datetime
from google.protobuf.timestamp_pb2 import Timestamp

import trainer_pb2
import trainer_pb2_grpc

class TrainerServiceServicer(trainer_pb2_grpc.TrainerServiceServicer):
    def GetTrainer(self, request, context):
        # Fecha de nacimiento estática
        birthday = Timestamp()
        birthday.FromDatetime(datetime.datetime(1990, 1, 1, tzinfo=datetime.timezone.utc))
        # Fecha de creación estática
        created_at = Timestamp()
        created_at.FromDatetime(datetime.datetime.utcnow().replace(tzinfo=datetime.timezone.utc))
        # Medallas estáticas
        medals = [
            trainer_pb2.Medals(region="RSU", type=trainer_pb2.MedalType.GOLD),
            trainer_pb2.Medals(region="KRA", type=trainer_pb2.MedalType.SILVER),
        ]
        return trainer_pb2.TrainerResponse(
            id=request.id,
            name="kemonito",
            age=18,
            birthday=birthday,
            medals=medals,
            created_at=created_at
        )


def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    trainer_pb2_grpc.add_TrainerServiceServicer_to_server(TrainerServiceServicer(), server)
    server.add_insecure_port('[::]:50051')
    server.start()
    print("Servidor gRPC iniciado en el puerto 50051")
    server.wait_for_termination()

if __name__ == '__main__':
    serve()