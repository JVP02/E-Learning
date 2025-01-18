using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameProject
{
    public static class SharedArray
    {
        // MAP ================================================================================================================
        public static int[] lvlNum = { 1, 2, 3, 4, 5 };
        public static string[] lvlDesc = { "Level 1 Description", "Level 2 Description", "Level 3 Description", "Level 4 Description", "Level 5 Description" };

        // Story ================================================================================================================
        public static string[] storyImg =   { "story11",    "MangkuStory",   "SirenaStory",   "scene4",   "scene5" };
        public static string[] storySound = { "story1",     "vo2",      "vo3",      "vo4",      "vo5" };

        // Character Related Arrays ==========================================================================================================
        public static string[] charIconImg =    { "KnightIcon",     "ArcherIcon",       "machIcon",             "gagamIcon",        "bagIcon",      "capbarIcon",       "darnaIcon" };
        public static string[] charName =       { "Traveller",      "Wilbert",          "Machete",              "Gagamboy",         "Bagwis",       "Captain Barbel",   "Wilbert"   };
        public static string[] charImg =        { "char1",          "char2",            "char3",                "char4",            "char5",        "char1",            "char2"     };
        public static string[] charIdleImg =    { "KnightIdle",     "ArcherIdle",       "machIdle",             "gagamIdle",        "bagIdle",      "capbarIdle",       "darnaIdle" };
        public static string[] charAtkImg =     { "KnightAtk",      "ArcherAtk",        "KnightAtk",            "gagamAtk",         "bagAtk",       "darnaAtk",         "darnaAtk"  };
        public static string[] charEffImg =     { "KE",             "ArcherEff",        "bagEff",               "gagamEff",         "bagEff",       "darnaEff",         "darnaEff"  };
        public static string[] charSkill =      { "KnightSkill",    "ArcherSkill",      "machSkill",            "gagamSkill",       "bagSkill",     "capbarSkill",      "darnaSkill" };
        public static string[] charUltImg =     { "ult1",           "ult2",             "ult1",                 "ult4",             "bagUlt",       "capbarUlt",         "darnaUlt"};
        public static string[] charUltSound =   { "ultSound",       "ultSound",         "ultSound",             "ultSound",         "ultSound",     "ultSound",         "ultSound",     "ultSound",         "ultSound",     "ultSound" };
        public static string[] charEle =        { "light",          "nature",           "water",                "fire",             "magic" };
        public static string[] charDeathImg =   { "AngelSlash",     "AngelSlash",       "AngelSlash",           "AngelSlash",       "AngelSlash",   "AngelSlash",   "AngelSlash" };
        public static string[] charEffSound =   { "AngelSlashound1", "AngelSlashound2", "AngelSlashound3",      "AngelSlashound4",  "AngelSlashound5" };

        // Player Stats
        public static int[] charHp =            { 600,              650,                450,                    500,                600,            600,            650 };
        public static int[] charAtk =           { 1000,             1500,               1200,                   1000,               1100,           1200,           1400 }; // Adjusted attack
        public static int[] charHeal =          {0,                 0,                  150,                    0,                  0,              0,              0 }; // Balanced healing


        // Items Related Arrays =================================================================================================================
        public static string[] iImg = { "Salt", "Amulet", "WoodStick", "Crucifix", "Gong", "Santelmo", "Dagger", "Spear", "Net" };
        public static string[] irlImg = { "itak", "binakuko", "bicuco", "item4", "item5", "item6", "item7", "item8", "item9", "item10" };
        public static string[] iName = { "Salt", "Amulet", "WoodStick", "Crucifix", "Gong", "Santelmo", "Dagger", "Spear", "Net" };
        public static string[] iDesc = {
            "When it comes to mythical creatures, salt’s effects are both practical and symbolic. Against the Aswang and Manananggal",
            "Amulets, locally known as anting-anting, hold an important role in Philippine culture and folklore, symbolizing the intersection of spiritual beliefs, mysticism, and the power of nature.",
            "The legendary spear used to defeat supernatural beings such as mermaids and siokoy finds its roots in the rich tapestry of Philippine folklore, where humans and mythical entities coexisted in a fragile and often tumultuous harmony.",
            "A crucifix, derived from the Latin cruci fixus, meaning \"fixed to a cross,\" is a religious symbol that holds profound significance within Christianity",
            "The gong, a traditional percussion instrument with deep cultural roots across Southeast Asia, holds a prominent place in Philippine folklore and mythology.",
            "Santelmo, a mysterious and luminous entity in Philippine folklore, is often depicted as a glowing, floating orb of light that appears unexpectedly in isolated or rural areas. ",
            "The silver dagger holds a significant place in Filipino folklore, valued not just for its sharpness, but for the purifying and protective properties attributed to it. Silver, often seen as a precious and pure metal, is believed to possess spiritual potency, capable of neutralizing dark forces and magical curses.",
            "In Filipino myths, the spear is especially associated with warriors and shamans who used it as both a weapon and a tool for invoking the divine. It is said that these spears were often blessed by spiritual leaders during rituals, imbuing them with magical properties that allowed them to kill or repel creatures that were otherwise impervious to ordinary weapons.",
            "In Philippine folklore, the rope is not merely a tool for tying or binding, but is imbued with significant supernatural properties. Its origins in myth trace back to early communities where it was used both as a practical tool and a symbol of unity and strength in rituals meant to protect individuals and villages from supernatural forces. "
            
        };
        //                              "Salt",     "Amulet",       "WoodStick",    "Crucifix",     "Gong",     "Santelmo",     "Dagger",   "Spear",    "Net"
        public static int[] iHP = {     700,        850,            500,            900,            950,        700,            850,        500,        900 };
        public static int[] iATK = {    80,         85,             50,             20,             10,         50,             80,         50,         90 };
        public static string[] iEle = { "light",    "nature",       "water",        "fire",         "magic",    "fire",         "light",    "light",    "light"};
        public static int[] iHB = {     80,         85,             50,             20,             10,         50,             80,         50,         90 };


        // Example arrays



        public static string[] itemImg = { "Salt", "Amulet", "WoodStick", "Crucifix", "Gong", "Santelmo", "Dagger", "Spear", "Net" };

        // DATA


        // Enemy Related Arrays =============================================================================================================
        public static string[] eImg = { "manaIcon", "mangkuIcon", "merIcon", "bakuIcon", "tikbIcon", "tyanIcon", "mangkuIcon", "merIcon", "bakuIcon", "tikbIcon", "tyanIcon" };

        public static string[][] enemIconImg = new string[][]
{
    new string[] { "manaIcon",      "manaIcon1",        "manaIcon2" },
    new string[] { "mangkuIcon",    "mangkuIcon1",      "mangkuIcon2" },
    new string[] { "merIcon",       "merIcon1",         "merIcon2" },
    new string[] { "bakuIcon",      "bakuIcon1",        "bakuIcon2" },
    new string[] { "tikbIcon",      "tikbIcon1",        "tikbIcon2" },
    new string[] { "tyanIcon",      "tyanIcon1",        "tyanIcon2" },
    new string[] { "mangkuIcon",    "mangkuIcon1",      "mangkuIcon2" },
    new string[] { "merIcon",       "merIcon1",         "merIcon2" },
    new string[] { "bakuIcon",      "bakuIcon1",        "bakuIcon2" },
    new string[] { "tikbIcon",      "tikbIcon1",        "tikbIcon2" }
    // Add more sets of three as needed for each level
};

        public static string[][] enemIdleImg = new string[][]
{
    new string[] { "mana",      "mana1",        "mana2" },
    new string[] { "mangku",    "mangku1",      "mangku2" },
    new string[] { "mer",       "mer1",         "mer2" },
    new string[] { "baku",      "baku1",        "baku2" },
    new string[] { "tikb",      "tikb1",        "tikb2" },
    new string[] { "tyan",      "tyan1",        "tyan2" },
    new string[] { "mangku",    "mangku1",      "mangku2" },
    new string[] { "mer",       "mer1",         "mer2" },
    new string[] { "baku",      "baku1",        "baku2" },
    new string[] { "tikb",      "tikb1",        "tikb2" }
    // Add more sets of three as needed for each level
};
        public static string[][] enemAtkImg = new string[][]
{
    new string[] { "manaAtk",   "manaAtk1",     "manaAtk2" },
    new string[] { "mangkuAtk", "mangku1Atk",   "mangkuAtk2" },
    new string[] { "merAtk",    "merAtk1",      "merAtk2" },
    new string[] { "bakuAtk",   "bakuAtk1",     "bakuAtk2" },
    new string[] { "tikbAtk",   "tikbAtk1",     "tikbAtk2" },
    new string[] { "tyanAtk",   "tyanAtk1",     "tyanAtk2" },
    new string[] { "mangkuAtk", "mangku1Atk",   "mangkuAtk2" },
    new string[] { "merAtk",    "merAtk1",      "merAtk2" },
    new string[] { "bakuAtk",   "bakuAtk1",     "bakuAtk2" },
    new string[] { "tikbAtk",   "tikbAtk1",     "tikbAtk2" }
    // Add more sets of three as needed for each level
    // Add more levels as needed
};
        public static string[][] enemEffImg = new string[][]
{
    new string[] { "AngelSlash", "AngelSlash", "AngelSlash" },
    new string[] { "AngelSlash", "AngelSlash", "AngelSlash" },
    new string[] { "AngelSlash", "AngelSlash", "AngelSlash" },
    new string[] { "AngelSlash", "AngelSlash", "AngelSlash" },
    new string[] { "AngelSlash", "AngelSlash", "AngelSlash" },
    new string[] { "AngelSlash", "AngelSlash", "AngelSlash" },
    new string[] { "AngelSlash", "AngelSlash", "AngelSlash" },
    new string[] { "AngelSlash", "AngelSlash", "AngelSlash" },
    new string[] { "AngelSlash", "AngelSlash", "AngelSlash" },
    new string[] { "AngelSlash", "AngelSlash", "AngelSlash" },
    // Add more sets of three as needed for each level
};
        public static string[][] enemEffSound = new string[][]
{
    new string[] { "enemSFX2", "enemSFX2", "enemSFX2" },
    new string[] { "enemSFX2", "enemSFX2", "enemSFX2" },
    new string[] { "enemSFX2", "enemSFX2", "enemSFX2" },
    new string[] { "enemSFX2", "enemSFX2", "enemSFX2" },
    new string[] { "enemSFX2", "enemSFX2", "enemSFX2" },
    new string[] { "enemSFX2", "enemSFX2", "enemSFX2" },
    new string[] { "enemSFX2", "enemSFX2", "enemSFX2" },
    new string[] { "enemSFX2", "enemSFX2", "enemSFX2" },
    new string[] { "enemSFX2", "enemSFX2", "enemSFX2" },
    new string[] { "enemSFX2", "enemSFX2", "enemSFX2" },
    // Add more sets of three as needed for each level
};

        public static string[][] enemDeathImg = new string[][]
{
    new string[] { "AngelSlash", "AngelSlash", "AngelSlash" }, // Level 1 enemy death setup
    new string[] { "AngelSlash", "AngelSlash", "AngelSlash" }, // Level 2 enemy death setup
    new string[] { "AngelSlash", "AngelSlash", "AngelSlash" }, // Level 3 enemy death setup
    new string[] { "AngelSlash", "AngelSlash", "AngelSlash" }, // Level 1 enemy death setup
    new string[] { "AngelSlash", "AngelSlash", "AngelSlash" }, // Level 2 enemy death setup
    new string[] { "AngelSlash", "AngelSlash", "AngelSlash" }, // Level 3 enemy death setup
    new string[] { "AngelSlash", "AngelSlash", "AngelSlash" }, // Level 3 enemy death setup
    new string[] { "AngelSlash", "AngelSlash", "AngelSlash" }, // Level 1 enemy death setup
    new string[] { "AngelSlash", "AngelSlash", "AngelSlash" }, // Level 2 enemy death setup
    new string[] { "AngelSlash", "AngelSlash", "AngelSlash" } // Level 3 enemy death setup
    // Add more levels as needed
};
        public static string[][] enemName = new string[][]
{
    new string[] { "Manananggal", "Manananggal", "Manananggal" }, // Level 1 enemy names
    new string[] { "Mangkukulam", "Mangkukulam", "Mangkukulam" }, // Level 2 enemy names
    new string[] { "Sirena", "Sirena", "Sirena" }, // Level 3 enemy names
    new string[] { "Manananggal", "Manananggal", "Manananggal" }, // Level 1 enemy names
    new string[] { "Mangkukulam", "Mangkukulam", "Mangkukulam" }, // Level 2 enemy names
    new string[] { "Sirena", "Sirena", "Sirena" }, // Level 3 enemy names
    new string[] { "Mangkukulam", "Mangkukulam", "Mangkukulam" }, // Level 2 enemy names
    new string[] { "Sirena", "Sirena", "Sirena" }, // Level 3 enemy names
    new string[] { "Mangkukulam", "Mangkukulam", "Mangkukulam" }, // Level 2 enemy names
    new string[] { "Sirena", "Sirena", "Sirena" }, // Level 3 enemy names

    // Add more levels as needed
};
        public static string[][] enemElem = new string[][]
{
    new string[] { "dark", "earth", "fire" }, // Level 1 enemy names
    new string[] { "water", "dark", "light" }, // Level 2 enemy names
    new string[] { "curse", "nature", "magic" }, // Level 3 enemy names
    new string[] { "dark", "earth", "fire" }, // Level 1 enemy names
    new string[] { "water", "dark", "light" }, // Level 2 enemy names
    new string[] { "curse", "nature", "magic" }, // Level 3 enemy names
    new string[] { "curse", "nature", "magic" }, // Level 3 enemy names
    new string[] { "dark", "earth", "fire" }, // Level 1 enemy names
    new string[] { "water", "dark", "light" }, // Level 2 enemy names
    new string[] { "curse", "nature", "magic" }, // Level 3 enemy names
    // Add more levels as needed
};
        // Enemy HP
        public static int[][] enemHp = new int[][]
        {
    new int[] { 450, 480, 500 },  // Level 1
    new int[] { 550, 570, 600 },  // Level 2
    new int[] { 650, 680, 700 },  // Level 3
    new int[] { 750, 770, 800 },  // Level 4
    new int[] { 850, 880, 900 },  // Level 5
    new int[] { 950, 980, 1000 }, // Level 6
    new int[] { 1050, 1080, 1100 }, // Level 7
    new int[] { 1150, 1180, 1200 }, // Level 8
    new int[] { 1250, 1280, 1300 }, // Level 9
    new int[] { 1350, 1380, 1400 }  // Level 10
        };

        // Enemy Attack
        public static int[][] enemAtk = new int[][]
        {
    new int[] { 80, 90, 100 },    // Level 1
    new int[] { 110, 120, 130 },  // Level 2
    new int[] { 140, 150, 160 },  // Level 3
    new int[] { 170, 180, 190 },  // Level 4
    new int[] { 200, 210, 220 },  // Level 5
    new int[] { 230, 240, 250 },  // Level 6
    new int[] { 260, 270, 280 },  // Level 7
    new int[] { 290, 300, 310 },  // Level 8
    new int[] { 320, 330, 340 },  // Level 9
    new int[] { 350, 360, 370 }   // Level 10
        };

        // Enemy Defense
        public static int[][] enemDef = new int[][]
        {
    new int[] { 50, 55, 60 },    // Level 1
    new int[] { 65, 70, 75 },    // Level 2
    new int[] { 80, 85, 90 },    // Level 3
    new int[] { 95, 100, 105 },  // Level 4
    new int[] { 110, 115, 120 }, // Level 5
    new int[] { 125, 130, 135 }, // Level 6
    new int[] { 140, 145, 150 }, // Level 7
    new int[] { 155, 160, 165 }, // Level 8
    new int[] { 170, 175, 180 }, // Level 9
    new int[] { 185, 190, 195 }  // Level 10
        };
        // Add more shared arrays here


        // Currency ===========================================================================================================================
        public static string[] coinImg = { "c100", "c125", "c150", "c200", "c250", "c300", "c350", "c500", "c750", "c900" };
        public static int[] coinVal = { 100, 125, 150, 200, 250, 300, 350, 500, 700, 900 };
        public static string[] gemImg = { "g5", "g5", "g5", "g10", "g10", "g10", "g20", "g20", "g20", "g30" };
        public static int[] gemVal = { 5, 5, 5, 10, 10, 10, 20, 20, 20, 30 };



        // "manaIcon", "mangkuIcon", "merIcon", "bakuIcon", "tikbIcon", "tyanIcon" 
        // Collection
        public static string[] icollIcon = {    "Salt",     "Amulet",                   "WoodStick",        "Crucifix",     "Gong",     "Santelmo",     "Dagger",       "Spear",    "Net" };
        public static string[] icollImg1 = {    "salt1",   "amulet2",                 "woodsteak1",            "crucifix1",        "gong2",    "santelmo2",        "dagger1",        "spear1",    "net1" };
        public static string[] icollImg2 = {    "salt2",     "amulet1",                 "woodsteak2",            "crucifix2",        "gong1",    "santelmo1",        "dagger2",        "spear2",    "net2" };
        public static string[] icollName = {    "Salt",     "Amulet (Anting-Anting)",   "Wooden Steak",     "Crucifix",     "Gong",     "Santelmo",     "Dagger",       "Spear",    "Net" };
        public static string[] icollDesc1 = {
            "Salt, a humble yet essential substance, holds a profound place in Philippine folklore, where it is revered as both a symbol of life and a formidable weapon against the supernatural. Its prominence in myth arises from its intrinsic qualities: purity, preservation, and its vital role in sustaining life. These attributes elevate salt from mere seasoning to a spiritual safeguard, embodying humanity's defense against malevolent forces. In the context of Philippine mythology, salt’s symbolic association with purity aligns it with rituals that repel corruption, darkness, and death. This belief is deeply rooted in cultural traditions, where salt is not only used in cooking but also in blessings, exorcisms, and protection rituals.\r\nThe origin of salt’s mystic power in Filipino lore may be traced to the archipelago's close relationship with the sea, a source of both sustenance and danger. Myths often depict early seafarers discovering the purifying and preserving properties of salt, viewing it as a divine gift from the gods. Stories speak of ancestors who, armed with nothing but salt, stood firm against the incursions of mythical creatures. One tale recounts a village plagued by an Aswang, a shape-shifting entity that preys on humans.",
            "Amulets, locally known as anting-anting, hold an important role in Philippine culture and folklore, symbolizing the intersection of spiritual beliefs, mysticism, and the power of nature. These talismans are considered to provide the bearer with protection, strength, and even supernatural abilities. The origins of anting-anting can be traced back to the pre-colonial animistic traditions of the indigenous peoples, where magical objects and spirits were believed to govern both the seen and unseen worlds. These beliefs were further enriched by influences from Hindu-Buddhist traditions, as well as the later arrival of Islam and Christianity, which infused the practice with elements of divine protection and sacred power.\r\nThe creation and use of anting-anting is not merely a matter of acquiring a physical object, but involves a deep spiritual process. Often, these amulets are crafted by healers, priests, or skilled artisans who imbue them with specific powers through rituals, prayers, and offerings. In many cases, anting-anting are believed to be at their most potent during particular sacred times, such as Good Friday or during special lunar phases, when spiritual energies are considered to be at their peak. These rituals link the object not only to the physical realm but to the divine forces that govern the universe.",
            "The legendary spear used to defeat supernatural beings such as mermaids and siokoy finds its roots in the rich tapestry of Philippine folklore, where humans and mythical entities coexisted in a fragile and often tumultuous harmony. This weapon's origins are said to lie in a time when humanity, though vulnerable, sought to assert its place in a world teeming with mysterious creatures and forces of nature. Forged from the strongest hardwood found in the dense forests of the archipelago, the spear was imbued with mystical properties through rituals performed by the babaylan, the revered shamans of pre-colonial Philippines. These rituals, involving chants, offerings, and invocations to the spirits of the land and sea, blessed the spear with the ability to pierce not only the physical bodies of these creatures but also their supernatural essence.\r\nThe spear’s creation is deeply tied to the duality of reverence and fear that Filipinos held for the natural world. Myths speak of its wood being harvested only during full moons, ensuring that it carried the blessings of lunar deities. The blade, often made of stone or later of metal, was sharpened and treated with herbs believed to ward off malevolent spirits. Legend has it that the first wielder of the spear was a fisherman whose village was plagued by nightly attacks from a vengeful siokoy, a malevolent sea creature resembling a humanoid fish.",
            "A crucifix, derived from the Latin cruci fixus, meaning \"fixed to a cross,\" is a religious symbol that holds profound significance within Christianity. Unlike a plain cross, which represents the Christian faith more generally, a crucifix features an image or sculpture of Jesus Christ nailed to the cross, symbolizing his sacrificial death. This representation is referred to as the corpus, from the Latin word meaning \"body,\" and it serves as a powerful visual reminder of Jesus' suffering and ultimate sacrifice for humanity's salvation.\r\nThe crucifix is a central and highly revered object in many Christian traditions, particularly within Catholicism and Eastern Orthodoxy. The image of Jesus hanging on the cross serves as a reminder of the immense suffering he endured, and it is seen as a symbol of love, compassion, and redemption. For Christians, Jesus' crucifixion is believed to have been the pivotal event that facilitated the redemption of mankind, offering salvation and forgiveness from sin through his sacrifice. The crucifix, therefore, embodies both the tragedy and triumph of Jesus' life and mission, as it marks the moment when, through his death, he atoned for the sins of the world.\r\nThroughout history, the crucifix has been used not only in religious rituals and ceremonies but also as a means of personal devotion and protection. In many Christian homes, a crucifix is placed in prominent locations to remind believers of Jesus’ love and the sacrifice he made.",
            "Historically, gongs were used by indigenous Filipino communities in various ceremonial contexts, such as weddings, harvest celebrations, and rituals invoking deities or spirits. However, they also served a more protective role in the face of supernatural threats. The gong’s sound was believed to be capable of dispelling evil spirits and malevolent creatures that roamed the earth or haunted particular areas. In the context of folklore, the gong is thought to have the ability to purify spaces by banishing restless spirits, such as ghosts or multo, who were believed to cause harm or misfortune to the living. The loud, distinct sound of the gong is said to “scatter” these spirits, disrupting their presence and forcing them to retreat into the spiritual realm. It was often struck during rituals to cleanse homes, shrines, or villages of negative energies or paranormal entities.\r\nThe gong’s influence extends to mythical creatures that are commonly feared in Philippine folklore, including forest-dwelling beings such as the kapre and tikbalang. These creatures, which are often depicted as powerful and elusive entities, are said to have a strong connection to nature. The gong’s sound, with its deep resonance, is believed to disturb this connection, making it unbearable for them to remain in the vicinity. Villagers would strike gongs to reclaim territories or areas where these creatures were thought to reside, as the sound was believed to drive them away, restoring peace and safety to the land.",
            "Santelmo, a mysterious and luminous entity in Philippine folklore, is often depicted as a glowing, floating orb of light that appears unexpectedly in isolated or rural areas. These ethereal lights are frequently seen near bodies of water, forests, or mountain ranges, typically at night, and they emit a bright, almost otherworldly blue or white glow. The appearance of Santelmo is most commonly associated with places where people are lost or in danger. For those wandering in the wilderness or traversing remote mountains, Santelmo is sometimes believed to act as a guide, leading them to safety. This guiding light, however, is not always benevolent. In some instances, Santelmo’s appearance can signal an impending threat or danger, such as a natural disaster, a fire, or illness. In many rural communities, it is seen as a harbinger of misfortune, often believed to precede events like storms, earthquakes, or even death. When Santelmo appears near a person or village, its frequent sightings are sometimes interpreted as an omen of an approaching death or a supernatural event.\r\nThe significance of Santelmo varies across regions, but one common belief is that it marks an encounter with the divine or the spirit world. The glowing orb is often linked to Christian iconography, especially the figure of Santo Niño (the Holy Child Jesus). According to this belief, Santelmo could be seen as a manifestation of divine intervention or spiritual protection. The connection with Santo Niño de Santelmo, in particular, suggests that the entity is not merely a supernatural phenomenon but an active form of communication from the spiritual realm.",
            "The silver dagger holds a significant place in Filipino folklore, valued not just for its sharpness, but for the purifying and protective properties attributed to it. Silver, often seen as a precious and pure metal, is believed to possess spiritual potency, capable of neutralizing dark forces and magical curses. In Filipino mythology, silver is considered to have a unique ability to repel malevolent spirits, creatures, and dark magic, making the silver dagger a powerful weapon against supernatural entities. Its importance stems from the belief that silver, unlike other metals, holds the power to cleanse spaces, individuals, and even objects of negative energy or evil influence. This makes the silver dagger not only a tool for self-defense but also a sacred item used in rituals to protect communities from the unseen forces that lurk in the world.\r\nThe silver dagger is especially effective against mythical creatures, which are often portrayed as vulnerable to its purifying qualities. Aswang, manananggal, and tikbalang—creatures known for their dangerous and supernatural abilities—are believed to be particularly susceptible to silver. Aswang, for instance, are said to be harmed or even killed by a silver dagger if it pierces their human form. This belief has given rise to tales of villagers wielding silver daggers in self-defense against these creatures. The manananggal, a vampiric entity that separates its upper body from its lower torso, is similarly vulnerable to silver. Some myths suggest that silver not only prevents its transformation but can also render it powerless. The tikbalang, a half-human, half-horse creature known for leading travelers astray, is also said to be repelled by silver, with the dagger serving as a means to drive it away.",
            "Rope in folklore is believed to be especially effective against creatures like the aswang, manananggal, and tiyanak, who are said to be vulnerable to being bound or restrained by its strong fibers. The act of binding a creature with a blessed rope is thought to render it powerless, either preventing its transformation or limiting its ability to attack. For example, the manananggal, known for its ability to separate its upper body from its lower half, is said to be unable to reassemble itself if its parts are bound by a sacred rope. In some stories, ropes are also used in protective rituals, where they are placed around homes or sacred spaces to ward off malevolent spirits and entities, effectively creating a barrier that keeps evil forces at bay. These ropes serve as a reminder of the strength and resilience of the community, whose unity can overcome even the most fearsome supernatural threats. Through this symbolism, the rope becomes more than just a physical object; it becomes a powerful tool of defense, hope, and spiritual strength.",
            "The spear is one of the oldest and most iconic weapons in Philippine folklore, deeply embedded in the history and mythology of the archipelago. Originating from the time when humans and mythical beings coexisted in a fragile balance, the spear was not just a tool for hunting or warfare, but a symbol of humanity’s strength, resilience, and ability to combat the supernatural. The creation of the spear is often attributed to the gods or spirits, who gave it to warriors or shamans to defend their communities from various threats, including mythical creatures. In some legends, the spear is forged with materials from sacred trees or imbued with the power of the elements, granting it supernatural capabilities.\r\nIn Filipino myths, the spear is especially associated with warriors and shamans who used it as both a weapon and a tool for invoking the divine. It is said that these spears were often blessed by spiritual leaders during rituals, imbuing them with magical properties that allowed them to kill or repel creatures that were otherwise impervious to ordinary weapons. The spear is also seen as a symbol of protection, carried by warriors and shamans who act as the first line of defense against malevolent entities. The sharp point of the spear is believed to pierce the veil between the physical world and the spirit realm, allowing the wielder to strike down creatures like the aswang, manananggal, or tikbalang. These creatures, though powerful and dangerous, are said to be vulnerable to the spear’s magical properties, which can harm or even kill them."
        };
        public static string[] icollDesc2 = {
            "When it comes to mythical creatures, salt’s effects are both practical and symbolic. Against the Aswang and Manananggal, salt creates an invisible barrier that these creatures cannot cross, thwarting their attempts to harm humans. It is said that sprinkling salt on their severed torsos prevents them from reattaching and thus ensures their demise. For spirits like the Tiyanak and Multo, salt serves as a potent deterrent, disrupting their malevolent energy and banishing them from sacred or safe spaces. These creatures, tied to the spiritual realm, find themselves weakened or dispelled by salt’s purifying essence.\r\nForest-dwelling beings such as the Kapre and Tikbalang are similarly affected, though in a different way. Salt is believed to disorient and weaken these creatures, keeping them at bay and preventing them from intruding into human settlements. Sprinkling salt around a campsite, for instance, is said to deter such entities from approaching. ",
            "In the context of Philippine folklore, anting-anting are predominantly used as a defense against malevolent supernatural creatures. These creatures, such as the aswang, manananggal, and tikbalang, are commonly believed to threaten human life with their harmful intentions. The anting-anting is said to offer powerful protection against such beings, either by repelling them or rendering the wearer invisible or invulnerable to their attacks. For example, the aswang, a shape-shifting creature that feeds on human flesh, can be thwarted by wearing an anting-anting, which makes the wearer invisible or immune to the creature's powers. Similarly, the manananggal, a vampiric entity with the ability to detach its upper torso from its lower body, is believed to be rendered powerless by the mystical aura of an anting-anting.\r\nBeyond protecting against these dark creatures, anting-anting are also believed to safeguard the wearer from malevolent spirits like the multo (ghosts) or from curses and hexes (barang) cast by witches or evil sorcerers",
            "The spear's effects on mythical creatures are as legendary as its creation. Against siokoy, the weapon is believed to disrupt the creature’s aquatic affinity, rendering it vulnerable on land and weakening its supernatural strength. A single strike to the chest or head is said to nullify the siokoy’s regenerative abilities, preventing it from rising again. When used against mermaids, the spear’s enchanted properties nullify their mesmerizing songs, breaking the trance they cast over their victims. In battle, it can penetrate their otherwise impenetrable scales, delivering a fatal blow to creatures known for their resilience.\r\nAdditionally, the spear serves as a talisman against other aquatic threats, creating a protective aura around its wielder. In some tales, merely holding the spear is said to calm stormy seas, repel predatory sea creatures, and guide the lost safely back to shore. Its spiritual potency extends beyond its use as a weapon, symbolizing humanity's ability to stand firm against the forces of the unknown, bridging the gap between mortal courage and divine intervention.",
            "In addition to its religious significance, the crucifix also holds cultural importance. It is often given as a gift during important milestones such as baptisms, confirmations, and weddings, and it may be worn as jewelry in the form of a pendant or necklace. As a symbol of hope and protection, the crucifix is believed to bring spiritual solace to those who carry it or display it in their homes, offering a sense of divine presence and security.\r\nFor many, the crucifix is not merely a religious symbol but a source of strength and inspiration. Its portrayal of Jesus' sacrifice and suffering serves as a reminder of the transformative power of love and forgiveness. It calls Christians to reflect on the virtues of humility, selflessness, and grace, encouraging them to live in accordance with the teachings of Christ. Ultimately, the crucifix remains a timeless and powerful symbol of faith, sacrifice, and the promise of eternal life.",
            "Perhaps one of the most unique applications of the gong is its role in defending against the tiyanak, a malevolent spirit that disguises itself as a baby to lure unsuspecting individuals into danger. The gong’s ringing sound is thought to confuse and frighten the tiyanak, breaking its deceptive hold over its prey. The vibrations of the gong are believed to disturb the creature’s ability to deceive and manipulate, leaving it vulnerable or causing it to flee.\r\nIn addition to its use as a tool for spiritual protection, the gong is also symbolic of the unity between humans and the divine. It represents the heartbeat of the earth, signifying the interconnectedness of all living things and their shared responsibility for maintaining harmony and balance. Its power is not only a means of defense but also a way of asserting one’s connection to the earth and the cosmos, making it a revered and respected instrument in Filipino culture.",
            "Santelmo serves as a reminder of the deep spiritual connection between the physical world and the unseen forces that govern it.\r\nWhile Santelmo may sometimes be perceived as a protective guide, its unpredictability makes it a figure of ambivalence in folklore. Its appearance can be reassuring or foreboding, depending on the circumstances and local interpretations. Some stories describe it as a mischievous spirit, playing tricks on people, while others speak of it as a benevolent guide sent by higher powers to watch over the living. For some, seeing Santelmo is a sign of divine favor, while for others, it may be a warning of impending doom or supernatural events. The entity’s appearance remains a subject of fascination and fear, embodying the complex relationship between the seen and unseen in Filipino cultural beliefs. Santelmo, in its many forms, continues to evoke awe and reverence, blending religious iconography with the ancient Filipino understanding of spirits and the supernatural world.",
            "In addition to its use as a weapon, the silver dagger is integral to the practices of babaylan (shamans) and albularyo (healers), who are often called upon to protect their communities from supernatural threats. These spiritual practitioners are said to wield the dagger in protective rituals or even in direct combat with malevolent creatures. Silver's purifying properties are believed to enhance the dagger's effectiveness in banishing evil, neutralizing curses, and protecting individuals from harm. In folklore, the silver dagger's role extends beyond physical defense, embodying the idea of spiritual cleansing and the triumph of purity over darkness. Whether used in a ritual or in direct battle, the silver dagger remains a revered symbol of protection in Filipino culture.",
            "The rope’s magical properties extend beyond just being a weapon against mythical beings; it is also believed to have the ability to bind curses and break enchantments. It is said that when a rope is used in a ritual to sever the link between a victim and a malevolent spirit, it can nullify the spirit’s influence. Additionally, ropes are believed to be effective in restraining wandering spirits or entities like the tiyanak, which preys on the unsuspecting. By tying the spirit with the rope, the victim can free themselves from the spirit’s grasp. Even creatures like the kapre and tikbalang, who are notoriously difficult to catch or control, can be subdued if they are ensnared by a magical rope. As folklore evolved, ropes became symbolic of the strength of the human spirit, uniting people in their common struggle against supernatural forces. Whether used in battle or as a tool of spiritual defense, the rope remains a potent artifact in Filipino myth, embodying both the physical and mystical power that binds and protects.",
            "The spear’s power is also attributed to its association with elements like fire, water, and air, which are invoked during its creation or in rituals performed with it. In battles against mythical beings, it is often the spear that delivers the fatal blow to creatures like the tikbalang, whose strength and agility make them difficult to subdue with regular weapons. The spear’s effectiveness in combating these beings is not just physical but also spiritual. Some stories describe the spear as having the ability to disrupt the magical or supernatural abilities of these creatures, rendering them vulnerable to attack. The act of wielding the spear is often portrayed as a rite of passage, marking an individual’s readiness to confront the supernatural and protect their people from harm.\r\nIn addition to its use in direct combat, the spear plays a key role in Filipino spiritual practices. Shamans and babaylan would use the spear in rituals to exorcise evil spirits or protect individuals from curses. "
        };

        public static string[] ecollIcon = {    "manaIcon",         "mangkuIcon",       "merIcon",      "bakuIcon",     "tikbIcon",     "tyanIcon" };
        public static string[] ecollImg1 = {    "manananggal1",     "mangkukulam",      "sirena1",   "bakunawa",    "tikbalang1",        "tyanak" };
        public static string[] ecollImg2 = {    "manananggal",      "mangkukulam1",       "sirena2",       "bakunawa1",         "tikbalang",        "tyanak1" };
        public static string[] ecollImg3 = {    "Tikbalang2",       "binakuko",         "bicuco",       "item4",        "item5",        "item6" };
        public static string[] ecollName = {    "Manananggal",      "Mangkukulam",      "Sirena",       "Bakunawa",     "Tikbalang",    "Tyanak"};

        // Max character 1425
        public static string[] ecollDesc1 = {
            "The Manananggal, a prominent figure in Philippine folklore, is often associated with the province of Capiz, located in the Western Visayas region. Capiz has long been regarded as a hub of mysticism and supernatural tales, earning it a reputation as a place steeped in stories of witches (mangkukulam), shamans (albularyo), and mythical creatures. The Manananggal is one of the most feared and fascinating entities in Filipino mythology. It is typically described as a woman capable of severing her upper torso, sprouting bat-like wings, and flying off to hunt for unsuspecting victims, often pregnant women whose fetuses are said to be its primary prey. While the association with Capiz is strong, tales of the Manananggal also appear in other regions, including Iloilo and Antique, reflecting a broader cultural fascination with the creature. The prominence of these legends in Capiz is linked to its deeply rooted superstitions, the influence of pre-colonial animist beliefs, and the province's lush, isolated landscapes, which serve as fitting backdrops for eerie stories. These tales persist to this day, perpetuated by the oral traditions of locals and cementing the Manananggal as a staple of Philippine horror and cultural identity. ",
            "The mangkukulam, a figure in Filipino folklore, is a practitioner of folk magic often associated with witchcraft, curses, and sorcery. This practice is deeply rooted in Filipino culture, blending animism, Catholicism, and local superstitions. Commonly linked to regions like Iloilo, Capiz, Antique in the Visayas, and parts of Mindanao, the mangkukulam's craft often involves spells, potions, and talismans to influence others' fate, frequently with malevolent intent, though some claim to use their powers for healing. These practices, passed down through generations, are typically shrouded in secrecy due to societal stigma or legal repercussions.\r\nIn rural areas, the mangkukulam is viewed with a mix of fear and respect, as they are believed to manipulate both natural and supernatural realms. However, their powers are not without limits. Their reliance on rituals and spiritual energy makes them vulnerable to counter-spells and charms, like the protective anting-anting (amulets) or bato (stones), often crafted by shamans or spiritual healers. Their magical strength is tied to their health, meaning illness or weakness diminishes their abilities. The secrecy they require is another vulnerability; exposure can lead to ostracism, breaking their societal ties and undermining their influence.",
            "The Sirena, also known as the mermaid in Filipino mythology, is a legendary creature often associated with the seas and rivers of the Philippines. While mermaid-like creatures exist in various cultures around the world, the Sirena specifically has roots in the Visayan and Bicol regions, where seafaring and fishing are vital aspects of life. In Visayan folklore, particularly among the Cebuano and Ilonggo people, stories of Sirenas abound. These mermaids are depicted as beautiful women with the lower body of a fish, who sometimes fall in love with fishermen or lure them to their watery demise. The Bicol region also shares similar myths, with stories of Sirenas who possess enchanting voices that can summon sailors or fishermen, much like the Greek sirens. The widespread nature of the Sirena myth across various coastal and riverine provinces suggests that it has been influenced by the deep connection Filipinos have with their waters, whether it be the sea, rivers, or lakes. The tale of the Sirena continues to thrive in the oral traditions of these regions, symbolizing both the beauty and danger of the sea. In mythology, sirens (often referred to as sirenas in some cultures) are creatures known for their enchanting abilities, particularly their voice or song, which lures sailors to their doom. Traditionally, sirens are depicted as part-human, part-bird creatures in Greek mythology, though in later traditions, especially in modern folklore and fantasy, they are often represented as mermaids (half-human, half-fish beings).",
            "The Bakunawa is a prominent figure in Philippine mythology, particularly in the Visayan region. It is a mythical sea serpent or dragon, often depicted as a large, terrifying creature that swallows the moon during lunar eclipses. The origin of the Bakunawa is primarily tied to the Visayan provinces, especially in places like Cebu, Negros, and Leyte, where the myth is widely known and celebrated. The story of Bakunawa is deeply ingrained in the culture and belief systems of these regions, where it is said to be a powerful, celestial being capable of bringing about natural calamities, such as eclipses and floods. In the myth, Bakunawa was once a beautiful sea creature, with a massive body and seven great heads, each capable of causing destruction. The creature's obsession with the moon led it to attempt to devour it, triggering fear and awe among the people. The lunar eclipse was seen as a moment when Bakunawa succeeded in swallowing the moon, plunging the world into darkness. The people would then make loud noises, using gongs or shouting, to drive the creature away and restore the moon to its rightful place in the sky. The myth of Bakunawa is an important part of the indigenous beliefs and oral traditions in the Visayas, and its influence can still be seen in modern-day festivals and cultural expressions. Its story has been passed down through generations, serving not only as an explanation for lunar eclipses but also as a reminder of the power of nature and the mysteries of the universe.",
            "The tikbalang's exact provincial origin in the Philippines is a matter of some debate among folklore scholars, but it is most strongly associated with the provinces of Central and Southern Luzon, particularly in Quezon Province and the regions surrounding Metro Manila. The creature has deep roots in Tagalog mythology, where stories of the tikbalang have been passed down through generations by the indigenous peoples of these areas. In Quezon Province, particularly in the more remote and forested areas, the tikbalang is believed to be a guardian of the natural world, often appearing to travelers who disturb or disrespect the forest. The folklore is especially prevalent in towns near Mount Banahaw, where locals have long reported encounters with these horse-headed creatures. However, it's worth noting that as Filipino culture spread and evolved, tikbalang stories became integrated into the mythologies of other provinces as well, with variations of the creature appearing in Pampanga, Bulacan, and even as far as Bicol region. Each area has developed its own unique interpretation of the tikbalang's appearance, behavior, and significance, though the core description of a tall, humanoid figure with a horse's head remains consistent across these regional variations. I should note that since this involves very specific folkloric origins, some details might vary according to different oral traditions and sources.",
            "The Tyanak, a mythical creature in Philippine folklore, is most famously associated with the Tagalog and Visayan regions but is recognized in various provinces across the country. This creature is often described as a spirit or demon that assumes the form of an innocent baby or young child. It lures unsuspecting people with cries for help, typically in remote or forested areas. When someone approaches to offer aid, the Tyanak reveals its monstrous form and attacks, sometimes devouring its victim.\r\nThe legend of the Tyanak is particularly well-known in Luzon, especially in provinces like Batangas and Quezon, though similar tales exist in the Visayas and Mindanao. These stories suggest that while the Tyanak is most commonly linked to Tagalog-speaking areas, the concept of child-like spirits or shapeshifting creatures has evolved across the Philippines, reflecting regional interpretations of the myth.\r\nIn many versions of the story, the Tyanak is believed to be the vengeful spirit of a child who died before baptism, or a being created through dark sorcery. These variations highlight cultural themes surrounding life, death, and the afterlife, emphasizing the importance of rituals and spiritual protection in Filipino society. As a symbol of fear and caution, the Tyanak serves as a reminder of the unseen forces that influence human lives in Filipino folklore."
        };
        // Max Character 1000
        public static string[] ecollDesc2 = {
            "The Manananggal is a prominent figure in Filipino folklore, often described as a terrifying creature with the ability to separate its upper torso from its lower body and fly using bat-like wings. This grotesque transformation allows it to soar through the night, hunting for prey, which often includes sleeping pregnant women or infants. A signature feature of the Manananggal is its long, sharp tongue, used to suck blood or drain the life force of its victims. While its disjointed form makes it a powerful predator, it also exposes several vulnerabilities that can render it powerless. Garlic and salt are two well-known deterrents; the strong scent of garlic repels the creature, while salt sprinkled on its severed lower body prevents it from reattaching. Other substances like vinegar and ash are also believed to be effective. A wooden stake driven into the lower half can kill it outright, ensuring it cannot return to its human form. The Manananggal is most active at night and must reunite with its lower body by sunrise; failure to do so leaves it weak and vulnerable.",
            "The Mangkukulam, a figure in Filipino folklore, is a type of witch or sorcerer known for practicing black magic. They are often associated with causing harm through supernatural means, primarily using kulam (witchcraft). Their powers vary by region and legend but generally include several notable abilities.\r\nCursing or hexing is one of their primary skills, allowing them to inflict illness, misfortune, or even death, often driven by jealousy, anger, or personal motives. Mangkukulams are also adept spellcasters, using rituals and objects like dolls, herbs, or potions to manipulate nature, control minds, or cause harm. In some myths, they can shapeshift into animals, such as black cats, to perform their magical acts covertly.\r\nWhile many Mangkukulams are seen as malevolent, some possess healing abilities, using supernatural means to cure ailments. However, this may come with conditions, like demanding something in return or harming others.",
            "Their weaknesses vary depending on the version of the story. Here are a few common weaknesses associated with sirens or sirenas: Resistance to their songs: Some stories suggest that sirens lose their power over those who can resist their hypnotic songs. For instance, in Greek mythology, Odysseus had his crew plug their ears with beeswax to avoid being lured by the sirens.  Outwitting or distraction: In other tales, sirens can be outwitted or distracted, which may weaken their influence. For example, in some stories, heroes escape their songs by playing louder music or focusing on something else.  Connection to water: Sirens are often portrayed as water creatures. Being away from water or drying out can make them vulnerable or powerless in some versions.  Mortality: In certain myths, sirens are not immortal and can be harmed or killed like other creatures. In some variations of Greek myth, if a sailor manages to resist their song, the sirens will die",
            "This suggests that Bakunawa may not have full control over the moon, implying a limit to its power. Human Intervention: In various myths, human beings or gods play an important role in thwarting Bakunawa’s attempts. This shows that Bakunawa’s powers can be overcome by cooperation, strategy, or divine intervention. Physical Vulnerabilities: Some accounts mention that Bakunawa, being a massive sea serpent or dragon, might have weaknesses related to its size or its ability to move. Though not frequently depicted as weak in physical terms, its large size could potentially make it more vulnerable in combat situations, especially if trapped or surrounded. The Moon’s Protection: Some stories speak of magical items, such as special prayers or rituals, that could protect the moon from Bakunawa. These rituals and protections hint that there are mystical ways to stop Bakunawa, suggesting it is not invincible.",
            "The tikbalang is one of the most formidable creatures in Philippine mythology, possessing an impressive array of supernatural abilities and distinct physical characteristics that make it both feared and respected in Filipino folklore. Standing at an imposing height of seven to nine feet tall, the tikbalang possesses the head and hooves of a horse combined with the muscular body of a human, often described as having dark, coarse hair covering its body and glowing red eyes that pierce through the darkness. Among its most notable abilities is its power to disorient travelers by creating illusions that make people lose their way in forests, causing them to walk in circles for hours or even days. The creature is known for its exceptional strength and speed, capable of outrunning ordinary horses and leaping great distances with ease. Some versions of the legend claim that tikbalangs can turn invisible at will, particularly during stormy weather, and have the power to transform into human form to deceive unsuspecting victims.",
            "Despite its frightening powers, the Tiyanak is not invincible. Folklore identifies salt as an effective means of repelling the creature, creating a barrier against its attacks. Sacred objects, including crucifixes or holy water, are believed to weaken it due to its association with demonic forces. Loud noises, such as ringing bells or shouting, can disrupt its deceptive abilities, while fire is considered a powerful deterrent. The simplest protection is ignoring its cries, as not responding to its lure renders its trap ineffective. Spiritual defenses, such as prayers, rituals, or protective amulets called anting-anting, also offer reliable protection. The Tiyanak’s legend, often seen as a cautionary tale, reflects the Filipino cultural emphasis on compassion, fear, and belief in the supernatural. Its origins are sometimes tied to the vengeful spirit of an unbaptized child or the result of dark sorcery, further grounding its myth in themes of morality and spiritual retribution."

        };
        //public static string[] ecollDesc3 = {
        //    " However, like many mythological beings, the tikbalang also has specific weaknesses that humans can exploit. The most well-known method of subduing a tikbalang is to pluck three golden hairs from its mane, which can be used to tame the creature and even turn it into a loyal steed and protector. Another weakness is its susceptibility to strong faith - carrying religious items or reciting prayers is said to ward off the creature. Additionally, travelers can protect themselves from its disorienting powers by wearing their clothes inside out or carrying salt or garlic. Some stories suggest that tikbalangs can be detected by the strong smell of tobacco that accompanies their presence, and they are said to be particularly vulnerable during Friday nights. Perhaps their most peculiar weakness is their compulsive need to count every individual piece of ginger or bamboo that crosses their path, which clever humans can use as a distraction to escape their clutches.",
        //    "binakuko",
        //    "bicuco",
        //    "item4",
        //    "item5",
        //    "item6",
        //    "item7",
        //    "item8",
        //    "item9",
        //    "item10"
        //};

        // QUIZ ========================================================================================
        //==============================================================================================
        public static string[] quizQuest = {
    "What is a common method to ward off aswang?",
    "What is the characteristic smell of kapre?",
    "What is the physical form of manananggal during the night?",
    "What is the best way to confuse a tikbalang?",
    "Which tree is commonly associated with kapre?",
    "What item is often used as a weapon against supernatural creatures?",
    "What natural element is believed to repel tiyanak?",
    "Which phase of the moon strengthens an aswang?",
    "What is a common way to identify a manananggal in its human form?",
    "What should you avoid doing to prevent attracting a tiyanak?",
    "Which plant is believed to protect against supernatural entities?",
    "What is the weakness of a manananggal when separated from its lower body?",
    "What offering is believed to appease a kapre?",
    "What kind of oil is said to bubble when an aswang is nearby?",
    "Which item is most effective against a manananggal?",
    "Which creature is known for mimicking the sound of a crying baby?",
    "How can you safely pass through a kapre's territory?",
    "What is the best time to confront a manananggal?",
    "Which creature is associated with backward-facing feet?",
    "What is the significance of garlic in Filipino folklore?",
    "How do you protect yourself from a tikbalang's tricks?",
    "What happens if you destroy the lower body of a manananggal?",
    "What type of tree is often the home of a tikbalang?",
    "What offering is left at a balete tree to ward off spirits?",
    "What should you do to break a tiyanak’s curse?",
    "How do you trap a tikbalang?",
    "What time of day is most associated with aswang activity?",
    "What should you whisper when passing a kapre's territory?",
    "What must you use to defeat a manananggal in combat?",
    "What plant can repel a kapre?",
    "What happens to an aswang if it is exposed to sunlight?",
    "What should you carry to confuse a tikbalang?",
    "What natural element protects against spirits?",
    "What phase of the moon empowers a manananggal?",
    "What is sprinkled to banish spirits?",
    "What time of day is associated with kapre activity?",
    "What plant repels tikbalang?",
    "What should be done to pass safely through a kapre's domain?",
    "What is the human appearance of a manananggal?",
    "Which item traps a tikbalang?",
    "What is avoided to prevent being lost by a tikbalang?",
    "What oil bubbles when an aswang is nearby?",
    "What happens if a manananggal’s lower body is smeared with salt?",
    "What is done to purify a talisman?",
    "What kind of item is sacred in Filipino traditions?",
    "What blessing strengthens a silver dagger?",
    "What prevents a talisman’s power from fading?",
    "Who aids in rituals involving supernatural beings?",
    "What creature hides in balete trees?",
    "What is the best way to identify a disguised manananggal?",
    "What signals a tikbalang's presence?",
    "What trick exposes a tiyanak?",
    "Which creature leaves backward footprints?"
};


        public static string[] quizChoiceA = {
    "Burn incense", "A musky tobacco scent", "A half-bodied woman with wings",
    "Wear your clothes inside out", "Acacia Tree", "Blessed rope",
    "Bright light", "Crescent moon", "They have no reflection",
    "Crying out at night", "Garlic", "Destroy its wings",
    "Cigars", "Coconut oil", "Silver dagger",
    "Tiyanak", "Keep a candle lit", "During a solar eclipse",
    "Feet turned inward", "Drives away bad spirits", "Tie a red string on your wrist",
    "Its body regenerates instantly", "Aguho tree", "Milk",
    "Sing a lullaby", "Use a strong net", "Noon",
    "Pray aloud", "Blessed sword", "Rosemary",
    "It turns to stone", "Bring a piece of charcoal", "Water",
    "Half-moon", "Holy water", "Morning",
    "Mint leaves", "Shout loudly", "A young girl in a dress",
    "Holy beads", "Look down while walking", "Coconut oil",
    "It turns into dust", "Meditate under moonlight", "A necklace",
    "Blessed by a babaylan", "Keep it away from sunlight", "Priests",
    "A giant snake", "Observe their shadow", "Strange laughter",
    "Offer it food", "Faint human footprints"
};

    public static string[] quizChoiceB = {
    "Throw salt at them", "Sweet aroma of flowers", "A bat-like creature",
    "Whistle softly three times", "Balete Tree", "A silver dagger",
    "Saltwater", "Full moon", "They avoid mirrors",
    "Walking alone at night", "Burning sage", "Holy symbols",
    "Leaves and fruits", "Cooking oil", "A cross",
    "Kapre", "Pray under a tree", "During a full moon",
    "Backward feet", "Repels evil spirits", "Wear a talisman",
    "It disintegrates", "Narra tree", "Coins",
    "Say a prayer", "Trap it in a loop", "Midnight",
    "Say ‘tabi-tabi po’", "Holy water", "Bayabas leaves",
    "It vanishes", "Carry salt", "Fire",
    "New moon", "Blessed water", "Dusk",
    "Holy leaves", "Walk in silence", "A woman in black",
    "Silver amulet", "Avoid direct paths", "Blessed oil",
    "It melts away", "Bury it under the moon", "A sacred amulet",
    "A prayer ritual", "Light incense daily", "Shaman",
    "A manananggal", "Look for missing reflections", "Animal sounds",
    "Call its name", "Backward footsteps"
};

    public static string[] quizChoiceC = {
    "Pray loudly", "Burning incense", "A shadowy figure",
    "Spin three times in place", "Molave Tree", "Garlic necklace",
    "Holy water", "Half moon", "They avoid eye contact",
    "Lighting a fire", "Cross a river", "Holy symbols",
    "Rice grains", "Holy oil", "Sacred talisman",
    "Aswang", "Leave a gift", "During a lunar eclipse",
    "Clawed feet", "Wards off demons", "Carry a sacred crystal",
    "It collapses", "Bamboo tree", "Offerings",
    "Keep it under sunlight", "Ensnare it with threads", "Twilight",
    "Hum softly", "A silver chain", "Sacred tree sap",
    "It burns", "Carry vinegar", "Air",
    "Gibbous moon", "Sprinkle holy ash", "Afternoon",
    "Lemongrass", "Light a candle", "A cloaked figure",
    "Sacred beads", "Avoid whistling", "Bubble oil",
    "It evaporates", "Cleanse with rituals", "A sacred ring",
    "A holy chant", "Pray to spirits", "Elder priest",
    "A tikbalang", "Observe their shadow", "Howling winds",
    "Offer a toy", "Overlapping tracks"
};

    public static string[] quizChoiceD = {
    "Sprinkle holy water", "Coconut smell", "A winged beast",
    "Walk backward silently", "Narra Tree", "A sacred charm",
    "Cross a river", "New moon", "They have unusually long nails",
    "Praying loudly", "Lemongrass", "An enchanted weapon",
    "Sacred herbs", "Olive oil", "Wooden stakes",
    "Black dog", "Bow before entering", "During twilight",
    "Shadowy hands", "Blesses holy sites", "Offer flowers",
    "It becomes powerless", "Guava tree", "Whisper a lullaby",
    "Burn sacred leaves", "Create a maze", "Nightfall",
    "Whisper prayers", "A blessed blade", "Mangroves",
    "It dissolves", "Carry ash", "Sunlight",
    "Waxing moon", "Light sacred fire", "Evening",
    "Rosemary", "Whisper an apology", "A mysterious traveler",
    "Holy string", "Avoid eye contact", "Blessed potion",
    "It is immobilized", "Chant over a flame", "Sacred pendant",
    "A sacred blessing", "Avoid using talismans", "Babaylan",
    "A spirit", "Observe unusual shadows", "Rustling leaves",
    "Drop salt", "Turned footprints"
};

        public static int[] correctAnswers = new int[] {
    1,  // Randomized correct answer for question 1
    0,  // Randomized correct answer for question 2
    0,  // Randomized correct answer for question 3
    1,  // Randomized correct answer for question 4
    2,  // Randomized correct answer for question 5
    3,  // Randomized correct answer for question 6
    0,  // Randomized correct answer for question 7
    3,  // Randomized correct answer for question 8
    1,  // Randomized correct answer for question 9
    0,  // Randomized correct answer for question 10
    2,  // Randomized correct answer for question 11
    3,  // Randomized correct answer for question 12
    2,  // Randomized correct answer for question 13
    3,  // Randomized correct answer for question 14
    1,  // Randomized correct answer for question 15
    2,  // Randomized correct answer for question 16
    0,  // Randomized correct answer for question 17
    2,  // Randomized correct answer for question 18
    3,  // Randomized correct answer for question 19
    1,  // Randomized correct answer for question 20
    0,  // Randomized correct answer for question 21
    3,  // Randomized correct answer for question 22
    2,  // Randomized correct answer for question 23
    1,  // Randomized correct answer for question 24
    3,  // Randomized correct answer for question 25
    2,  // Randomized correct answer for question 26
    1,  // Randomized correct answer for question 27
    0,  // Randomized correct answer for question 28
    2,  // Randomized correct answer for question 29
    3,  // Randomized correct answer for question 30
    0,  // Randomized correct answer for question 31
    1,  // Randomized correct answer for question 32
    3,  // Randomized correct answer for question 33
    2,  // Randomized correct answer for question 34
    0,  // Randomized correct answer for question 35
    1,  // Randomized correct answer for question 36
    3,  // Randomized correct answer for question 37
    2,  // Randomized correct answer for question 38
    1,  // Randomized correct answer for question 39
    3   // Randomized correct answer for question 40
};


    }
}
