package main

import (
	"os"

	"github.com/Josue_Uribe_Ugalde/p2p_chat/internal/peer"
)

func main() {
	operation := os.Args[1]
	connection := os.Args[2]
	username := os.Args[3]
	if operation == "connect" {
		peer.ConnectToPeer(connection, username)
	} else {
		peer.StartListening(connection, username)
	}
}
