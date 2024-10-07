﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zork
{

    public class Player
    {
        public World World { get; }

        [JsonIgnore] public Room Location { get; set; }

        [JsonIgnore]
        public string LocationName
        {
            get => Location?.Name;
            set => Location = World?.RoomsByName[value];
        }

        [JsonIgnore] public int Moves { get; set; }

        public Player(World world, string startingLocation)
        {
            World = world;
            Location = World.RoomsByName[startingLocation];
        }

        public bool Move(Directions direction)
        {
            var isValidMove = Location.Neighbors.TryGetValue(direction, out var room);

            if (isValidMove)
                Location = room;

            return isValidMove;
        }
    }
}
