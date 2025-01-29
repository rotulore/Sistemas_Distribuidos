FROM golang:1.23.4 as build
WORKDIR /app

COPY go.mod ./
RUN go mod download

COPY . ./
RUN CGO_ENABLED=0 GOOS=linux go build -o /chat ./cmd/chat
ENTRYPOINT [ "/chat" ]