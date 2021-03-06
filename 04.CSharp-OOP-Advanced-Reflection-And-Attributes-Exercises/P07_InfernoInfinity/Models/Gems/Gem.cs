﻿using P07_InfernoInfinity.Contracts;
using P07_InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Models.Gems
{
    public abstract class Gem : IGem
    {
        private int strength;
        private int agility;
        private int vitality;

        protected Gem(int strength, int agility, int vitality, Clarity clarity)
        {
            this.Clarity = clarity;
            this.Strength = strength;
            this.Agility = agility;
            this.Vitality = vitality;
        }

        public int Strength
        {
            get { return this.strength; }
            private set
            {
                this.strength = value + (int)this.Clarity;
            }
        }

        public int Agility
        {
            get { return this.agility; }
            private set
            {
                this.agility = value + (int)this.Clarity;
            }
        }

        public int Vitality
        {
            get { return this.vitality; }
            private set
            {
                this.vitality = value + (int)this.Clarity;
            }
        }

        public Clarity Clarity { get; }
    }
}
