﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Zork
{

    public class World
    {
        [JsonProperty] public string StartingLocation { get; set; }

        public HashSet<Room> Rooms { get; set; }


        private Dictionary<string, Room> _roomsByName;
        [JsonIgnore] public IReadOnlyDictionary<string, Room> RoomsByName => _roomsByName;

        public Player SpawnPlayer() => new Player(this, StartingLocation);

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            // Create a dictionary of rooms by name
            _roomsByName = Rooms.ToDictionary(n => n.Name, n => n);

            foreach (var room in Rooms)
                _roomsByName[room.Name].UpdateNeighbors(this);
        }
    }
}