using System;

namespace Prophet.Terminal.Interface
{
    public class Atom
    {
        public ConsoleColor Background { get; set; } = ConsoleColor.Black;
        public ConsoleColor Foreground { get; set; } = ConsoleColor.Gray;

        public char Character { get; set; } 



        public Atom()
            {}
        
        public Atom(char character, ConsoleColor foreground, ConsoleColor background)
        {
            Character = character;
            Foreground = foreground;
            Background = background;
        }


        public static bool operator ==(Atom a1, Atom a2) => a1?.Equals((object) a2) ?? a2?.Equals(null) ?? true;

        public static bool operator !=(Atom a1, Atom a2) => !(a1 == a2);
        
        
        
        protected bool Equals(Atom other)
        {
            return Background == other.Background && Foreground == other.Foreground && Character == other.Character;
        }

        public override bool Equals(object obj)
        {
            return !ReferenceEquals(null, obj) &&
                   (ReferenceEquals(this, obj) || obj.GetType() == GetType() && Equals((Atom) obj));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Background.GetHashCode();
                hashCode = (hashCode * 397) ^ (int) Foreground;
                hashCode = (hashCode * 397) ^ Character.GetHashCode();
                return hashCode;
            }
        }
    }
}