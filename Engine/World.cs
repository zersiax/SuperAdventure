using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class World
    {
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();

        public const int ITEM_ID_BOOT_DISK = 1;
        public const int ITEM_ID_SURFACE = 2;
        public const int ITEM_ID_STICK_OF_RAM = 3;
        public const int ITEM_ID_STICKER = 4;
        public const int ITEM_ID_SLEEVE = 5;
        public const int ITEM_ID_ULTRABOOK = 6;
        public const int ITEM_ID_MOUNTAIN_DEW = 7;
        public const int ITEM_ID_SSD = 8;
        public const int ITEM_ID_IPAD = 9;
        public const int ITEM_ID_ENTRY_BADGE = 10;

        public const int MONSTER_ID_IT_EMPLOYEE = 1;
        public const int MONSTER_ID_PIMPER = 2;
        public const int MONSTER_ID_PARTS_VENDOR = 3;

        public const int QUEST_ID_BUG_HUNT = 1;
        public const int QUEST_ID_ACCESSIBILITY_WEBINAR = 2;

        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_CAMPUS = 2;
        public const int LOCATION_ID_RECEPTION_DESK = 3;
        public const int LOCATION_ID_DEV_DIV = 4;
        public const int LOCATION_ID_CAFETERIA = 5;
        public const int LOCATION_ID_PUBLIC_RELATIONS = 6;
        public const int LOCATION_ID_STARBUX = 7;
        public const int LOCATION_ID_BRIDGE = 8;
        public const int LOCATION_ID_IT_CENTRAL = 9;

        static World()
        {
            PopulateItems();
            PopulateMonsters();
            PopulateQuests();
            PopulateLocations();
        }

        private static void PopulateItems()
        {
            Items.Add(new Weapon(ITEM_ID_BOOT_DISK, "Boot disk", "Boot Disks", 0, 5));
            Items.Add(new Item(ITEM_ID_SURFACE, "Microsoft Surface", "Microsoft Surfaces"));
            Items.Add(new Item(ITEM_ID_STICK_OF_RAM, "Stick of RAM memory", "sticks of RAM memory"));
            Items.Add(new Item(ITEM_ID_STICKER, "Awesome sticker", "Awesome Stickers"));
            Items.Add(new Item(ITEM_ID_SLEEVE, "Awesome Notebook sleeve with bunnies on it", "Awesome notebook sleeves with bunnies on them"));
            Items.Add(new Weapon(ITEM_ID_ULTRABOOK, "Ubertron 3000 ultrabook", "Ubertron 3000 ultrabooks", 3, 10));
            Items.Add(new HealingPotion(ITEM_ID_MOUNTAIN_DEW, "Can of Mountain Dew", "cans of Mountain Dew", 5));
            Items.Add(new Item(ITEM_ID_SSD, "SSD Disk", "SSD disks"));
            Items.Add(new Item(ITEM_ID_IPAD, "IPad", "IPads"));
            Items.Add(new Item(ITEM_ID_ENTRY_BADGE, "Entry badge", "entry badges"));
        }

        private static void PopulateMonsters()
        {
            Monster employee  = new Monster(MONSTER_ID_IT_EMPLOYEE, "Disgruntled IT man", 5, 3, 10, 3, 3);
            employee.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SURFACE), 75, false));
            employee.LootTable.Add(new LootItem(ItemByID(ITEM_ID_STICK_OF_RAM), 75, true));

            Monster pimper = new Monster(MONSTER_ID_PIMPER, "Pimp My Tech employee", 5, 3, 10, 3, 3);
            pimper.LootTable.Add(new LootItem(ItemByID(ITEM_ID_STICKER), 75, false));
            pimper.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SLEEVE), 75, true));

            Monster vendor  = new Monster(MONSTER_ID_PARTS_VENDOR, "Greasy parts vendor", 20, 5, 40, 10, 10);
            vendor.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SSD), 75, true));
            vendor.LootTable.Add(new LootItem(ItemByID(ITEM_ID_IPAD), 25, false));

            Monsters.Add(employee);
            Monsters.Add(pimper);
            Monsters.Add(vendor);
        }

        private static void PopulateQuests()
        {
            Quest bugHunt =
                new Quest(
                    QUEST_ID_BUG_HUNT,
                    "Fix all the bugs in this release of SuperOS",
                    "While fixing bugs you will run into some colleagues who are rage-quitting. Defeat them. You will receive a can of Mountain Dew and 10 gold pieces.", 20, 10);

            bugHunt.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_SURFACE), 3));

            bugHunt.RewardItem = ItemByID(ITEM_ID_MOUNTAIN_DEW);

            Quest accessibilityWebinar  =
                new Quest(
                    QUEST_ID_ACCESSIBILITY_WEBINAR,
                    "Hold a webinar on accessibility",
                    "In the audience are some very enraged Pimp My Tech employees who don't care much for your attitude. Defeat them and obtain three stickers.. You will receive an entry badge and 20 gold pieces.", 20, 20);

            accessibilityWebinar.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_STICKER), 3));

            accessibilityWebinar.RewardItem = ItemByID(ITEM_ID_ENTRY_BADGE);

            Quests.Add(bugHunt);
            Quests.Add(accessibilityWebinar);
        }

        private static void PopulateLocations()
        {
            // Create each location
            Location home = new Location(LOCATION_ID_HOME, "Home", "Your house. You really need to clean up the place.");

            Location campus = new Location(LOCATION_ID_CAMPUS, "Company campus", "Nice big company campus. But why is that elephant in the middle of it?");

            Location devDiv = new Location(LOCATION_ID_DEV_DIV, "Developer's Division", "Lots of developers happily coding away.");
            devDiv.QuestAvailableHere = QuestByID(QUEST_ID_BUG_HUNT);

            Location cafeteria  = new Location(LOCATION_ID_CAFETERIA, "The Cafeteria", "Loads of variety on the menu here");
            cafeteria.MonsterLivingHere = MonsterByID(MONSTER_ID_IT_EMPLOYEE);

            Location pr = new Location(LOCATION_ID_PUBLIC_RELATIONS, "Public Relations", "Why is everyone in here wearing a suit?");
            pr.QuestAvailableHere = QuestByID(QUEST_ID_ACCESSIBILITY_WEBINAR);

            Location starbux = new Location(LOCATION_ID_STARBUX, "Starbux", "COFFEE! JAVA! ...uuhm ....c#?");
            starbux.MonsterLivingHere = MonsterByID(MONSTER_ID_PARTS_VENDOR);

            Location reception  = new Location(LOCATION_ID_RECEPTION_DESK, "Reception Desk", "You are being asked for your badge. Better cough it up, you're holding up the line", ItemByID(ITEM_ID_ENTRY_BADGE));

            Location bridge = new Location(LOCATION_ID_BRIDGE, "Bridge", "A stone bridge crosses a wide river.");

            Location it = new Location(LOCATION_ID_IT_CENTRAL, "IT Department", "Loads of coffee cups cover abandoned desks. Guess it's lunchtime");
            it.MonsterLivingHere = MonsterByID(MONSTER_ID_PARTS_VENDOR);

            // Link the locations together
            home.LocationToNorth = campus;

            campus.LocationToNorth = devDiv;
            campus.LocationToSouth = home;
            campus.LocationToEast = reception;
            campus.LocationToWest = starbux;

            starbux.LocationToEast = campus;
            starbux.LocationToWest = cafeteria;

            cafeteria.LocationToEast = starbux;

            devDiv.LocationToSouth = campus;
            devDiv.LocationToNorth = pr;

            pr.LocationToSouth = devDiv;

            reception.LocationToEast = bridge;
            reception.LocationToWest = campus;

            bridge.LocationToWest = reception;
            bridge.LocationToEast = it;

            it.LocationToWest = bridge;

            // Add the locations to the static list
            Locations.Add(home);
            Locations.Add(campus);
            Locations.Add(reception);
            Locations.Add(devDiv);
            Locations.Add(cafeteria);
            Locations.Add(starbux);
            Locations.Add(pr);
            Locations.Add(bridge);
            Locations.Add(it);
        }

        public static Item ItemByID(int id)
        {
            foreach (Item item in Items)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }

            return null;
        }

        public static Monster MonsterByID(int id)
        {
            foreach (Monster monster in Monsters)
            {
                if (monster.ID == id)
                {
                    return monster;
                }
            }

            return null;
        }

        public static Quest QuestByID(int id)
        {
            foreach (Quest quest in Quests)
            {
                if (quest.ID == id)
                {
                    return quest;
                }
            }

            return null;
        }

        public static Location LocationByID(int id)
        {
            foreach (Location location in Locations)
            {
                if (location.ID == id)
                {
                    return location;
                }
            }

            return null;
        }
    }
}