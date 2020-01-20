using ChessOnline;
using Math.Tools.Primitives;
using Newtonsoft.Json;
using Server.Enum;
using Server.Pieces;
using Server.Pieces.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
namespace Server
{
    public static class Core
    {
        private static List<Room> Rooms = new List<Room>();

        public static User Elaborate(User user)
        {
            if (Rooms.Count == 0)
            {
                Room room1 = new Room("room0");
                Rooms.Add(room1);
                user.SetRoomKey(room1, Enum.Side.White);
                room1.Users.Add(user);
                return user;
            }
            foreach (Room room in Rooms)
            {
                foreach (User userInList in room.Users)
                {
                    if (userInList.UserName == user.UserName)
                    {
                        room.Board.ChessBoard.TryGetValue(user.StartPosition, out Piece startPiece);
                        room.Board.ChessBoard.TryGetValue(user.EndPosition, out Piece endPiece);
                        startPiece.Move();
                        foreach (Vector check in startPiece.Checks)
                            return userInList;
                    }
                }
            }
            foreach (Room room in Rooms)
            {
                foreach (User userInList in room.Users)
                {
                    if (room.Users.Count == 1)
                    {
                        user.SetRoomKey(room, Enum.Side.Black);
                        room.Users.Add(user);
                        room.Board = new Board(room.Users);


                        AsynchronousSocketListener.Send(room.Users[0].StateObject.workSocket, (JsonConvert.SerializeObject(room.Users[0]) + "<EOF>"));
                        AsynchronousSocketListener.Send(room.Users[1].StateObject.workSocket, (JsonConvert.SerializeObject(room.Users[1]) + "<EOF>"));
                        return user;
                    }

                }
            }


            string roomName = $"room{Rooms.Count}";
            Room room2 = new Room(roomName);
            Rooms.Add(room2);
            user.SetRoomKey(room2, Enum.Side.White);
            room2.Users.Add(user);
            return user;
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

        public static void MoveCreator(Piece piece)
        {
            piece.User.Room.Board.ChessBoard.Clear();
            for (double i = 0; i == 8; i++)
            {
                Enum.Direction direction1 = (Enum.Direction)i;
                if (piece.DirectionSteps[(int)i] != 0)
                {
                    for (double j = 1; j <= piece.DirectionSteps[(int)i]; j++)
                    {
                        if (piece.User.Room.Board.ChessBoard.ContainsKey(Cardinal(direction1, piece.User.StartPosition, j)))
                        {
                            piece.User.Room.Board.ChessBoard.TryGetValue(Cardinal(direction1, piece.User.StartPosition, j), out Piece piece1);
                            piece.User.Room.Board.ChessBoard.TryGetValue(piece.User.StartPosition, out Piece piece2);
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
        }
    }
}
