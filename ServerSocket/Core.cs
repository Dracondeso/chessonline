using ChessOnline;
using Server.Pieces;
using Server.Pieces.Abstraction;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
namespace Server
{
    public static class Core
    {
        private static List<Room> Rooms = new List<Room>();

        private static User Elaborate(User user)
        {
            if (Rooms.Count == 0)
            {
                string roomName = "room0";
                Room room1 = new Room(roomName);
                Rooms.Add(room1);
            }
            bool found = false;
            foreach (Room room in Rooms)
            {
                foreach (User userInList in room.Board.Users)
                {
                    if (userInList.UserName == user.UserName)
                    {
                        room.Board.ChessBoard.TryGetValue(user.StartPosition, out Piece startPiece);
                        room.Board.ChessBoard.TryGetValue(user.EndPosition, out Piece endPiece);

                     foreach (Vector check in startPiece.Move( )
                        return userInList;
                    }
                }
            }
            if (!found)
            {
                foreach (Room room in Rooms)
                {
                    foreach (User userInList in room.Board.Users)
                    {
                        if (userInList.UserName == null)
                        {
                            userInList.SetUser(user);
                            found = true;
                            return userInList;
                        }
                    }
                }
            }
            if (!found)
            {
                string roomName = $"room{Rooms.Count + 1}";
                Room room2 = new Room(roomName);
                Rooms.Add(room2);
                foreach (User userInList in room2.Board.Users)
                {
                    if (userInList.Side==Enum.Side.White)
                    {
                        userInList.SetUser(user);
                        return userInList;
                    }
                }
            }
            return user;
        }

        public PieceChoser(Piece piece)
        {
           

        }
    }
}
