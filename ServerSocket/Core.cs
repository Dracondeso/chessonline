using ChessOnline;
using Math.Tools.Primitives;
using Newtonsoft.Json;
using Server.Enum;
using Server.Networking;
using Server.Pieces;
using Server.Pieces.Abstraction;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
namespace Server
{
    public static class Core
    {
        private static List<Room> Rooms = new List<Room>();
        private static Dictionary<User, StateObject> StateObjects = new Dictionary<User, StateObject>();
        public static User AssignRoom(User user)
        {
            if (Rooms.Count == 0)
            {
                Room room1 = new Room("room0");
                Rooms.Add(room1);
                user.SetRoomKey(room1, Enum.Side.White);
                user.YourTurn = true;
                room1.Users.Add(user);
                return user;
            }
            foreach (Room room in Rooms)
            {
                    if (room.Users.Count == 1)
                    {
                        user.SetRoomKey(room, Enum.Side.Black);
                        user.YourTurn = false;
                        room.Users.Add(user);
                        room.Board = new Board(room.Users);
                    string jsonWhite = JsonConvert.SerializeObject(room.Users[0]); 
                    string jsonBlack = JsonConvert.SerializeObject(room.Users[1]);
                    StateObjects.TryGetValue(room.Users[0], out StateObject white);
                    StateObjects.TryGetValue(room.Users[1], out StateObject black);
                    AsynchronousSocketListener.Send(white.workSocket, jsonWhite);
                    AsynchronousSocketListener.Send(black.workSocket, jsonBlack);
                        return user;
                    }
            }
            string roomName = $"room{Rooms.Count}";
            Room room2 = new Room(roomName);
            Rooms.Add(room2);
            user.SetRoomKey(room2, Enum.Side.White);
            room2.Users.Add(user);
            return user;
        }
        public static void Elaborate(User user, StateObject state)
        {
            if (Core.GetStateObject(user) == null)
            {
                Core.AssignRoom(user);
                state.SetUser(user);
                return;
            }
            else
            {
                ;

                Dictionary<Vector, Piece> board = FindLoggedUserBoard(user);
                foreach (Vector check in FindPiece(user).Move())
                {
                    if (check.Equals(user.EndPosition))
                    {
                        foreach (User user1 in user.Room.Users)
                        {
                            if (user != user1)
                            {
                                SendMove(user, user1);
                                Console.WriteLine("Mossa Consentita");
                            }
                        }
                    }
                }
            }
        }
        public static void SendMove(User userTurn, User otherUser)
        {
            RefreshBoard(userTurn, userTurn.Room.Board.ChessBoard);
            otherUser.Room.Board.ChessBoard = userTurn.Room.Board.ChessBoard;
            StateObjects.TryGetValue(userTurn, out StateObject objectTurn);
            StateObjects.TryGetValue(otherUser, out StateObject otherObject);
            userTurn.YourTurn = false;
            otherUser.YourTurn = true;

            string jsonTurn = JsonConvert.SerializeObject(userTurn);
            string otherJson = JsonConvert.SerializeObject(otherUser);
            AsynchronousSocketListener.Send(objectTurn.workSocket, jsonTurn);
            AsynchronousSocketListener.Send(otherObject.workSocket, otherJson);

        }
        public static Dictionary<Vector, Piece> FindLoggedUserBoard(User user)
        {
            foreach (Room room in Rooms)
            {
                foreach (User userInList in room.Users)
                {
                    if (userInList.UserName == user.UserName)
                    {
                        return room.Board.ChessBoard;
                    }
                }
            }
            return null;
        }
        private static Vector Cardinal(Direction direction, Vector position, double increment)
        {
            Vector check = new Vector();
            switch (direction)
            {
                default:
                    throw new NotImplementedException("Unrecognized value.");
                case Enum.Direction.north:
                    check.Update(position.X, (position.Y + increment));
                    return check;
                case Enum.Direction.south:
                    check.Update(position.X, (position.Y - increment));
                    return check;
                case Enum.Direction.east:
                    check.Update((position.X + increment), position.Y);
                    return check;
                case Enum.Direction.west:
                    check.Update((position.X - increment), position.Y);
                    return check;
                case Enum.Direction.northEast:
                    check.Update((position.X + increment), (position.Y + increment));
                    return check;
                case Enum.Direction.northWest:
                    check.Update((position.X - increment), (position.Y + increment));
                    return check;
                case Enum.Direction.southEast:
                    check.Update((position.X + increment), (position.Y - increment));
                    return check;
                case Enum.Direction.southWest:
                    check.Update((position.X - increment), (position.Y - increment));
                    return check;
            }
        }
        public static StateObject GetStateObject(User user)
        {
            if (StateObjects.ContainsKey(user))
            {
                StateObjects.TryGetValue(user, out StateObject GettedState);
                return GettedState;
            }
            else
                return null;

        }
        public static Dictionary<Vector, Piece> RefreshBoard(User user, Dictionary<Vector, Piece> board)
        {
            board.TryGetValue(user.StartPosition, out Piece piece);
            board.Remove(user.StartPosition);
            board.Remove(user.EndPosition);
            board.Add(user.EndPosition, piece);
            return board;
        }
        public static List<Vector> Move(User user)
        {
            Piece piece = FindPiece(user);
            for (double i = 0; i == 8; i++)
            {
                Enum.Direction direction1 = (Enum.Direction)i;
                if (piece.DirectionSteps[(int)i] != 0)
                {
                    for (double j = 1; j <= piece.DirectionSteps[(int)i]; j++)
                    {
                        if (user.Room.Board.ChessBoard.ContainsKey(Cardinal(direction1, piece.User.StartPosition, j)))
                        {
                            user.Room.Board.ChessBoard.TryGetValue(Cardinal(direction1, piece.User.StartPosition, j), out Piece piece1);
                            user.Room.Board.ChessBoard.TryGetValue(piece.User.StartPosition, out Piece piece2);
                            if ((piece1.Side == piece2.Side) || (piece2.Name.Equals(Enum.PieceType.King)))
                            {
                                break;
                            }
                            else
                            {
                                piece.Checks.Add(Cardinal(direction1, piece.User.StartPosition, i));
                                break;
                            }
                        }
                        piece.Checks.Add(Cardinal(direction1, piece.User.StartPosition, i));
                    }
                }
            }
            return piece.Checks;
        }
        public static void ClearListVector(User user)
        {
            user.Room.Board.ChessBoard.Clear();

        }
        public static Piece FindPiece(User user)
        {
            user.Room.Board.ChessBoard.TryGetValue(user.StartPosition, out Piece piece);
            return piece;
        }
        public static User DeserializedJson(string stringToConvert)
        {
            User user = JsonConvert.DeserializeObject<User>(stringToConvert);
            return user;
        }
        public static string SerializedJson(User user)

        {
            return JsonConvert.SerializeObject(user);
        }

    }

}
