package peer

import (
	"bufio"
	"fmt"
	"net"
)

var username string

func StartListening(port string, user string) {
	username = user
	listener, err := net.Listen("tcp", ":"+port)

	if err != nil {
		fmt.Println("Error listening", err.Error())
		return
	}

	defer listener.Close()
	fmt.Printf("Peer is listenning on port %v....", port)
	for {
		conn, err := listener.Accept()
		if err != nil {
			fmt.Println("Error accepting connections: ", err.Error())
			continue
		}
		go receiveMessage(conn)
		sendMessage(conn)
	}
}

func receiveMessage(conn net.Conn) {
	defer conn.Close()
	reader := bufio.NewReader(conn)
	message, _ := reader.ReadString('\n')
	fmt.Println(message)
}

func sendMessage(conn net.Conn) {
	write := bufio.NewWriter(conn)
	fmt.Println("Connected to perr .Typy your message:")
	message := "this is the fisrt message"
	_, err := write.WriteString(message)
	if err != nil {
		fmt.Println("Error sending message:", err.Error())
	}
	write.Flush()
}

func ConnectToPeer(addres string, user string) {
	username = user
	conn, err := net.Dial("tcp", addres)
	if err != nil {
		fmt.Println(err.Error())
		return
	}
	defer conn.Close()
	go receiveMessage(conn)
	sendMessage(conn)
}
