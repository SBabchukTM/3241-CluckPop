using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using Runtime.Game;

public static class ExerciseProgramGenerator
{
    private const string RootFolder = "Assets/ProjectAssets/Settings/Exercises";

    [MenuItem("Tools/Generate Exercise Programs")]
    public static void Generate()
    {
        var data = new Dictionary<string, Dictionary<string, List<ExerciseDayData>>>();

        // UPPER BODY
        AddPrograms(data, "Upper", "Easy", new[]{
            ("Knee Push-ups",10,"Keep back straight"),("Assisted Pull-ups",5,"Use bar + foot assistance"),
            ("Wall Push-ups",15,"Stand 2ft from wall"),("Incline Rows",12,"Use sturdy table edge"),
            ("Knee Push-ups",12,"Slow descent (3 sec)"),("Assisted Pull-ups",6,"Focus on controlled lowering"),
            ("Shoulder Taps",20,"In plank position"),("Plank Rows",10,"Use table for support"),
            ("Box Push-ups",15,"Hands on elevated surface"),("Jumping Pull-ups",8,"Use bar + explosive jump assistance"),
            ("Wide-Arm Push-ups",12,"Knees on ground, hands wider"),("Inverted Rows",15,"Under table, body straight"),
            ("Knee Push-ups",15,"Pause 1 sec at bottom"),("Assisted Pull-ups",8,"Minimize foot assistance")
        });

        AddPrograms(data, "Upper", "Normal", new[]{
            ("Standard Push-ups",15,"Full body alignment"),("Pull-ups",6,"Use bar, no assistance"),
            ("Diamond Push-ups",12,"Hands form triangle"),("Chin-ups",8,"Palms facing you"),
            ("Pike Push-ups",10,"Hips high, mimic handstand"),("Commando Pull-ups",5,"Alternate sides on bar"),
            ("Archer Push-ups",8,"Shift weight to one arm"),("Negative Pull-ups",10,"5-sec slow descent"),
            ("Push-ups w/Rotation",10,"Rotate torso after each rep"),("L-sit Pull-ups",6,"Legs parallel to ground"),
            ("Clap Push-ups",8,"Explosive push, land softly"),("Wide-Grip Pull-ups",8,"Hands wider than shoulders"),
            ("Standard Push-ups",25,"2 sec up/2 sec down"),("Pull-ups",12,"Full range of motion")
        });

        AddPrograms(data, "Upper", "Hard", new[]{
            ("Decline Push-ups",15,"Feet on elevated surface"),("Weighted Pull-ups",8,"Add backpack with books"),
            ("One-Arm Push-ups",5,"Use wall for balance"),("Muscle-ups",3,"Use bar, explosive transition"),
            ("Spiderman Push-ups",12,"Knee to elbow each rep"),("Typewriter Pull-ups",6,"Move horizontally on bar"),
            ("Plyo Push-ups",10,"Hands leave ground each rep"),("Behind-Neck Pull-ups",8,"Bar touches upper back"),
            ("Handstand Push-ups",8,"Feet against wall"),("Mixed-Grip Pull-ups",10,"Alternate palms facing/away"),
            ("Aztec Push-ups",6,"Explosive jump to plank position"),("One-Arm Pull-ups",3,"Use towel for assistance"),
            ("Decline Push-ups",25,"3-sec pause at bottom"),("Weighted Pull-ups",15,"Max difficulty backpack")
        });

        // LOWER BODY
        AddPrograms(data, "Lower", "Easy", new[]{
            ("Chair Squats",15,"Tap chair lightly"),("Standing Lunges",10,"Use wall for balance"),
            ("Glute Bridges",20,"Squeeze glutes at top"),("Calf Raises",25,"Hold ledge for balance"),
            ("Supported Squats",20,"Hold doorframe"),("Step-ups",12,"Use stairs or curb"),
            ("Wall Sit",30,"Back flat against wall"),("Lying Leg Lifts",15,"Keep legs straight"),
            ("Sumo Squats",18,"Toes pointed out"),("Reverse Lunges",12,"Step backward"),
            ("Single-Leg Bridges",10,"One foot elevated"),("Jumping Jacks",40,"Low impact option available"),
            ("Chair Squats",25,"No chair touch (air squats)"),("Standing Lunges",15,"3-sec hold at bottom")
        });

        AddPrograms(data, "Lower", "Normal", new[]{
            ("Pistol Squats",5,"Hold doorframe"),("Jump Lunges",10,"Land softly"),
            ("Single-Leg Deadlifts",12,"Use wall for balance"),("Tuck Jumps",15,"Knees to chest"),
            ("Bulgarian Squats",10,"Rear foot on chair"),("Lateral Jumps",20,"Over imaginary line"),
            ("Cossack Squats",8,"Wide stance, shift weight"),("Skater Hops",15,"Leap side-to-side"),
            ("Squat Jumps",20,"Explode upward"),("Curtsy Lunges",12,"Cross leg behind"),
            ("Wall Sit",60,"Add calf raises during hold"),("Burpees",12,"No push-up (stand up)"),
            ("Pistol Squats",10,"Minimal assistance"),("Jump Lunges",20,"Continuous motion")
        });

        AddPrograms(data, "Lower", "Hard", new[]{
            ("Shrimp Squats",8,"Hold back foot with hand"),("Box Jumps",15,"Use park bench/stairs"),
            ("Nordic Ham Curls",6,"Anchor feet under couch"),("Broad Jumps",10,"Max distance per jump"),
            ("Sissy Squats",12,"Heels lifted, knees forward"),("180° Squat Jumps",8,"Rotate mid-air"),
            ("Single-Leg Squats",10,"No support"),("Depth Jumps",12,"Step off curb + explode up"),
            ("Dragon Flags",6,"Lie on bench, lift legs/torso"),("Plyo Lunges",12,"Switch legs mid-air"),
            ("Hindu Squats",25,"Heels up, fluid motion"),("Triple Jump",8,"Hop-step-jump sequence"),
            ("Shrimp Squats",15,"5-sec pause at bottom"),("Box Jumps",25,"Max height bench")
        });

        // CORE
        AddPrograms(data, "Core", "Easy", new[]{
            ("Knee Plank",30,"Keep hips low"),("Dead Bugs",20,"Alternate arm/leg"),
            ("Seated Russian Twists",25,"Feet on floor"),("Bird Dogs",15,"Extend arm/leg slowly"),
            ("Forearm Plank",40,"Squeeze glutes"),("Heel Taps",30,"Lie down, tap heels side-to-side"),
            ("Crunches",25,"Hands behind head, no pull"),("Leg Raises",15,"Knees bent"),
            ("Side Plank (Knees)",20,"Stack knees"),("Bicycle Crunches",30,"Slow and controlled"),
            ("Reverse Crunches",20,"Lift hips off ground"),("Plank Shoulder Taps",16,"Knees down if needed"),
            ("Forearm Plank",60,"Add hip dips last 15 sec"),("Dead Bugs",30,"Pause 2 sec at extension")
        });

        AddPrograms(data, "Core", "Normal", new[]{
            ("Hollow Hold",45,"Arms/legs lifted off ground"),("V-Ups",15,"Touch toes at top"),
            ("L-Sit",20,"Use parallettes/ground"),("Windshield Wipers",12,"Legs 90° to floor"),
            ("Dragon Flags",8,"Bent knees, lift hips"),("Plank to Pike",15,"From plank, lift hips high"),
            ("Side Plank Crunch",12,"Bring knee to elbow"),("Flutter Kicks",40,"Keep legs straight"),
            ("Ab Wheel Rollouts",10,"Use towel on slippery floor"),("Hanging Knee Raises",15,"Use public bar"),
            ("Cocoons",20,"Crunch + leg raise simultaneously"),("Plank Jacks",30,"Jump feet wide/narrow"),
            ("Hollow Hold",90,"Rock gently"),("V-Ups",25,"Hold 3 sec at top")
        });

        AddPrograms(data, "Core", "Hard", new[]{
            ("Human Flag Prep",8,"Use pole, tuck knees"),("Front Lever Tucks",10,"Use bar, body parallel"),
            ("Planche Lean",30,"Hands back, lean forward"),("Toes-to-Bar",12,"Use public bar"),
            ("L-Sit to Handstand",6,"Kick up against wall"),("Russian Lever",10,"Lift legs/torso with pulse"),
            ("Hanging Leg Raises",20,"Straight legs to bar"),("360° Plank",5,"Rotate on hands/feet"),
            ("Dragon Flags",15,"Straight legs, full range"),("Pike Press",8,"Mimic handstand push-up"),
            ("One-Arm Plank",20,"Stack feet"),("Human Flag",3,"Use pole, partial tuck"),
            ("Front Lever",10,"Tuck position on bar"),("Planche Push-ups",5,"Feet elevated, lean forward")
        });

        // Create assets
        foreach (var typeEntry in data)
        {
            foreach (var diffEntry in typeEntry.Value)
            {
                string folderPath = Path.Combine(RootFolder, typeEntry.Key, diffEntry.Key);
                Directory.CreateDirectory(folderPath);

                for (int i = 0; i < diffEntry.Value.Count; i++)
                {
                    var dayData = diffEntry.Value[i];
                    string fileName = $"{typeEntry.Key}_{diffEntry.Key}_Day {i + 1}.asset";
                    string assetPath = Path.Combine(folderPath, fileName).Replace("\\", "/");
                    AssetDatabase.CreateAsset(Object.Instantiate(dayData), assetPath);
                }
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("✅ All exercise programs generated successfully!");
    }

    private static void AddPrograms(Dictionary<string, Dictionary<string, List<ExerciseDayData>>> data,
                                    string type, string difficulty,
                                    (string name, int reps, string hint)[] raw)
    {
        if (!data.ContainsKey(type))
            data[type] = new Dictionary<string, List<ExerciseDayData>>();

        if (!data[type].ContainsKey(difficulty))
            data[type][difficulty] = new List<ExerciseDayData>();

        for (int i = 0; i < raw.Length; i += 2)
        {
            var day = ScriptableObject.CreateInstance<ExerciseDayData>();
            day.ExerciseOne = new ExerciseData
            {
                Name = raw[i].name,
                Reps = raw[i].reps,
                Hint = raw[i].hint
            };
            day.ExerciseTwo = new ExerciseData
            {
                Name = raw[i + 1].name,
                Reps = raw[i + 1].reps,
                Hint = raw[i + 1].hint
            };
            data[type][difficulty].Add(day);
        }
    }
}
