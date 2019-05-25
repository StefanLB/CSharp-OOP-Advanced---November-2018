using _08.PetClinic.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _08.PetClinic
{
    public class Clinic : IEnumerable<Pet>
    {
        private string clinicName;
        private int numberOfRooms;
        private Pet[] roomsWithPets;
        private RoomTracker roomTracker;

        public Clinic(string name, int numberOFRooms)
        {
            this.clinicName = name;
            this.NumberOfRooms = numberOFRooms;
            this.roomsWithPets = new Pet[numberOfRooms];
            roomTracker = new RoomTracker(numberOFRooms);
        }
        public string ClinicName
        {
            get { return clinicName; }
            private set { this.clinicName = value; }
        }

        public int NumberOfRooms
        {
            get { return numberOfRooms; }
            set
            {
                if (value%2==0)
                {
                    throw new InvalidOperationException($"Invalid Operation!");
                }
                numberOfRooms = value;
            }
        }

        public bool HasEmptyRooms() => roomTracker.EmptyRooms > 0;

        public Pet this[int index]
        {
            get
            {
                return this.roomsWithPets[index];
            }
            set
            {
                this.roomsWithPets[index] = value;
            }
        }

        public bool AddPet(Pet pet)
        {
            if (!(roomTracker.EmptyRooms > 0))
            {
                return false;
            }

            var index = roomTracker.GiveNextEmptyRoom();
            this.roomsWithPets[index] = pet;

            return true;
        }

        public bool ReleasePet()
        {
            bool isReleased = roomTracker
                .MakeEmptyRoom(this.roomsWithPets, roomTracker.StartingRoom, roomTracker.TotalRooms);

            if (isReleased)
            {
                return true;
            }
            return roomTracker.MakeEmptyRoom(this.roomsWithPets, 0, roomTracker.StartingRoom);
        }

        public IEnumerator<Pet> GetEnumerator()
        {
            foreach (var pet in this.roomsWithPets)
            {
                yield return pet;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
