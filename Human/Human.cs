namespace Human{
    public class Human{
        // public int numOrgans = 10;
        public string name;
        public int strength = 3;
        public int intelligence = 3;
        public int dexerity = 3;
        public int health = 100;

        public Human(string nam)
        {
            name=nam;
        }
        public Human(string nam, int strng, int intell, int dex, int heal)
        {
           name = nam;
           strength =strng;
           intelligence = intell;
           dexerity = dex;
           health = heal;
        }
        public void Attack(object target)
        {
            Human enemy = target as Human; 
            if(enemy != null)
            {
                enemy.health -= 5* strength;
            }
        }
    }
}