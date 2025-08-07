#if UNITY_EDITOR
using System.Collections.Generic;
using Runtime.Game;
using UnityEditor;
using UnityEngine;

public class ExerciseConfigGenerator
{
    [MenuItem("Tools/Generate/ExerciseDatabaseConfig (Upper Only)")]
    public static void GenerateUpperExerciseConfig()
    {
        var config = ScriptableObject.CreateInstance<ExerciseDatabaseConfig>();

        config.UpperExercises = new List<ExerciseExplanation>
        {
            new()
            {
                ExerciseName = "Knee Push-ups",
                ExerciseDescription =
                    "Start on hands and knees, hands shoulder-width apart\nCross ankles behind you, keep straight line from knees to head\nLower chest to floor by bending elbows\nPush back up to starting position"
            },
            new()
            {
                ExerciseName = "Wall Push-ups",
                ExerciseDescription =
                    "Stand arm's length from wall\nPlace palms flat against wall at shoulder height\nLean forward, bending elbows\nPush back to starting position"
            },
            new()
            {
                ExerciseName = "Box Push-ups",
                ExerciseDescription =
                    "Place hands on elevated surface (box/bench)\nStep feet back to plank position\nLower chest to surface\nPush back up"
            },
            new()
            {
                ExerciseName = "Standard Push-ups",
                ExerciseDescription =
                    "Start in plank position, hands shoulder-width apart\nLower body until chest nearly touches floor\nKeep core tight and body straight\nPush back up to starting position"
            },
            new()
            {
                ExerciseName = "Wide-Arm Push-ups",
                ExerciseDescription =
                    "Place hands wider than shoulder-width\nLower chest to floor\nKeep elbows flared out\nPush back up"
            },
            new()
            {
                ExerciseName = "Diamond Push-ups",
                ExerciseDescription =
                    "Form diamond shape with hands (thumbs and index fingers touching)\nLower chest to hands\nKeep elbows close to body\nPush back up"
            },
            new()
            {
                ExerciseName = "Pike Push-ups",
                ExerciseDescription =
                    "Start in downward dog position (hips high)\nLower head toward floor between hands\nKeep hips elevated throughout\nPush back to start"
            },
            new()
            {
                ExerciseName = "Archer Push-ups",
                ExerciseDescription =
                    "Start with wide hand placement\nLower to one side, extending opposite arm\nPush back up\nAlternate sides"
            },
            new()
            {
                ExerciseName = "Push-ups w/Rotation",
                ExerciseDescription =
                    "Perform standard push-up\nAt top, rotate torso and raise one arm skyward\nReturn to center\nAlternate sides each rep"
            },
            new()
            {
                ExerciseName = "Clap Push-ups",
                ExerciseDescription =
                    "Perform explosive push-up\nPush hard enough to lift hands off ground\nClap hands mid-air\nLand softly and lower into next rep"
            },
            new()
            {
                ExerciseName = "Spiderman Push-ups",
                ExerciseDescription =
                    "Lower into push-up\nBring one knee toward same-side elbow\nReturn leg while pushing up\nAlternate sides"
            },
            new()
            {
                ExerciseName = "Plyo Push-ups",
                ExerciseDescription =
                    "Lower into push-up position\nExplosively push up\nHands leave ground briefly\nLand softly, immediately lower again"
            },
            new()
            {
                ExerciseName = "Decline Push-ups",
                ExerciseDescription =
                    "Place feet on elevated surface\nHands on ground in push-up position\nLower chest to floor\nPush back up"
            },
            new()
            {
                ExerciseName = "Handstand Push-ups",
                ExerciseDescription =
                    "Kick up into handstand against wall\nLower head toward floor\nPress back up to full arm extension\nKeep core tight throughout"
            },
            new()
            {
                ExerciseName = "Aztec Push-ups",
                ExerciseDescription =
                    "Start in push-up position\nExplosively push up and forward\nLift entire body off ground\nLand back in push-up position"
            },
            new()
            {
                ExerciseName = "One-Arm Push-ups",
                ExerciseDescription =
                    "Spread feet wide for balance\nPlace one hand behind back\nLower chest with working arm\nPush back up"
            },
            new()
            {
                ExerciseName = "Assisted Pull-ups",
                ExerciseDescription =
                    "Grip bar with hands shoulder-width apart\nPlace feet on chair/ground for support\nPull up using arms, minimal leg assistance\nLower with control"
            },
            new()
            {
                ExerciseName = "Jumping Pull-ups",
                ExerciseDescription =
                    "Stand under bar\nJump and grab bar while pulling up\nUse jump momentum to complete pull-up\nLower with control"
            },
            new()
            {
                ExerciseName = "Pull-ups",
                ExerciseDescription =
                    "Hang from bar, palms facing away\nPull body up until chin over bar\nLower with control\nKeep core engaged"
            },
            new()
            {
                ExerciseName = "Chin-ups",
                ExerciseDescription =
                    "Grip bar with palms facing you\nPull up until chin over bar\nLower slowly\nKeep shoulders back"
            },
            new()
            {
                ExerciseName = "Wide-Grip Pull-ups",
                ExerciseDescription =
                    "Grip bar wider than shoulders\nPull up focusing on lats\nChin over bar\nControl descent"
            },
            new()
            {
                ExerciseName = "Negative Pull-ups",
                ExerciseDescription =
                    "Jump or step to top position (chin over bar)\nLower body slowly (5+ seconds)\nDrop and reset\nRepeat"
            },
            new()
            {
                ExerciseName = "L-sit Pull-ups",
                ExerciseDescription =
                    "Hang from bar\nRaise legs parallel to ground\nMaintain L position while pulling up\nLower with legs still raised"
            },
            new()
            {
                ExerciseName = "Commando Pull-ups",
                ExerciseDescription =
                    "Grip bar with hands close, one in front of other\nPull up to one side of bar\nLower and repeat\nAlternate sides"
            },
            new()
            {
                ExerciseName = "Weighted Pull-ups",
                ExerciseDescription =
                    "Wear weighted vest or backpack\nPerform standard pull-up\nFocus on controlled movement\nFull range of motion"
            },
            new()
            {
                ExerciseName = "Muscle-ups",
                ExerciseDescription =
                    "Hang from bar with false grip\nPull explosively high (chest to bar)\nTransition elbows over bar\nPress to straight arms"
            },
            new()
            {
                ExerciseName = "Typewriter Pull-ups",
                ExerciseDescription =
                    "Pull up to one side\nShift horizontally to other side while up\nLower down\nReverse direction next rep"
            },
            new()
            {
                ExerciseName = "Behind-Neck Pull-ups",
                ExerciseDescription =
                    "Grip bar slightly wider than shoulders\nPull up bringing bar behind neck\nTouch bar to upper back/neck\nLower with control"
            },
            new()
            {
                ExerciseName = "Mixed-Grip Pull-ups",
                ExerciseDescription =
                    "One palm facing you, one away\nPull up evenly\nLower with control\nSwitch grip each set"
            },
            new()
            {
                ExerciseName = "One-Arm Pull-ups",
                ExerciseDescription =
                    "Grip bar with one hand\nUse towel in other hand for minimal assistance\nPull up keeping body straight\nLower with control"
            },
            new()
            {
                ExerciseName = "Incline Rows",
                ExerciseDescription =
                    "Lie under sturdy table/bar at angle\nPull chest to surface\nKeep body straight\nLower with control"
            },
            new()
            {
                ExerciseName = "Inverted Rows",
                ExerciseDescription =
                    "Lie under bar/table\nBody straight, heels on ground\nPull chest to bar\nLower slowly"
            },
            new()
            {
                ExerciseName = "Shoulder Taps",
                ExerciseDescription =
                    "Start in plank position\nLift one hand to tap opposite shoulder\nMinimize hip movement\nAlternate hands"
            },
            new()
            {
                ExerciseName = "Plank Rows",
                ExerciseDescription =
                    "Start in plank with hands on elevated surface\nRow one arm up, elbow past ribs\nReturn to plank\nAlternate arms"
            }
        };

        config.LowerExercises = new List<ExerciseExplanation>
        {
            new()
            {
                ExerciseName = "Chair Squats",
                ExerciseDescription =
                    "Stand in front of chair\nLower until buttocks lightly touch seat\nDon't fully sit\nStand back up"
            },
            new()
            {
                ExerciseName = "Supported Squats",
                ExerciseDescription =
                    "Hold doorframe or sturdy object\nLower into squat position\nUse support for balance only\nPush through heels to stand"
            },
            new()
            {
                ExerciseName = "Sumo Squats",
                ExerciseDescription =
                    "Stand with feet wider than shoulders\nToes pointed outward\nLower straight down\nPush through heels to stand"
            },
            new()
            {
                ExerciseName = "Pistol Squats",
                ExerciseDescription =
                    "Stand on one leg\nExtend other leg forward\nLower down on standing leg\nPush back up (use support if needed)"
            },
            new()
            {
                ExerciseName = "Bulgarian Squats",
                ExerciseDescription =
                    "Place rear foot on chair/bench\nLower front knee to 90 degrees\nKeep torso upright\nPush through front heel to stand"
            },
            new()
            {
                ExerciseName = "Cossack Squats",
                ExerciseDescription =
                    "Take very wide stance\nShift weight to one side, bending that knee\nKeep other leg straight\nAlternate sides"
            },
            new()
            {
                ExerciseName = "Squat Jumps",
                ExerciseDescription =
                    "Lower into squat\nExplode upward\nLand softly in squat position\nImmediately repeat"
            },
            new()
            {
                ExerciseName = "180° Squat Jumps",
                ExerciseDescription =
                    "Lower into squat\nJump and rotate 180 degrees\nLand in squat facing opposite direction\nRepeat, alternating directions"
            },
            new()
            {
                ExerciseName = "Shrimp Squats",
                ExerciseDescription =
                    "Hold one foot behind you with same-side hand\nLower down on standing leg\nKeep held leg bent behind\nPush back up"
            },
            new()
            {
                ExerciseName = "Sissy Squats",
                ExerciseDescription =
                    "Hold support for balance\nRise onto toes\nLean back and bend knees forward\nLower until thighs parallel to ground"
            },
            new()
            {
                ExerciseName = "Hindu Squats",
                ExerciseDescription =
                    "Start standing, arms extended forward\nLower into squat on toes\nSweep arms back\nStand while bringing arms forward"
            },
            new()
            {
                ExerciseName = "Single-Leg Squats",
                ExerciseDescription =
                    "Stand on one leg\nLower down keeping other leg off ground\nMaintain balance\nPush back up"
            },
            new()
            {
                ExerciseName = "Standing Lunges",
                ExerciseDescription =
                    "Step forward with one leg\nLower back knee toward ground\nKeep front knee over ankle\nPush back to start"
            },
            new()
            {
                ExerciseName = "Reverse Lunges",
                ExerciseDescription =
                    "Step backward with one leg\nLower back knee toward ground\nKeep torso upright\nReturn to standing"
            },
            new()
            {
                ExerciseName = "Jump Lunges",
                ExerciseDescription =
                    "Start in lunge position\nJump and switch legs mid-air\nLand in opposite lunge\nImmediately repeat"
            },
            new()
            {
                ExerciseName = "Curtsy Lunges",
                ExerciseDescription =
                    "Step one leg behind and across other leg\nLower into curtsy position\nKeep hips square\nReturn to start"
            },
            new()
            {
                ExerciseName = "Plyo Lunges",
                ExerciseDescription =
                    "Start in lunge position\nJump explosively upward\nSwitch legs mid-air\nLand softly in opposite lunge"
            },
            new()
            {
                ExerciseName = "Step-ups",
                ExerciseDescription =
                    "Place one foot on step/bench\nPush through heel to step up\nBring other foot up\nStep down with control"
            },
            new()
            {
                ExerciseName = "Box Jumps",
                ExerciseDescription =
                    "Stand facing box/bench\nBend knees and swing arms back\nJump onto box\nLand softly, step down"
            },
            new()
            {
                ExerciseName = "Broad Jumps",
                ExerciseDescription =
                    "Stand with feet hip-width apart\nSwing arms back and bend knees\nJump forward as far as possible\nLand softly"
            },
            new()
            {
                ExerciseName = "Depth Jumps",
                ExerciseDescription =
                    "Stand on low platform\nStep off (don't jump)\nUpon landing, immediately jump up\nFocus on quick ground contact"
            },
            new()
            {
                ExerciseName = "Triple Jump",
                ExerciseDescription =
                    "Take running start or stand still\nHop on one foot\nStep onto opposite foot\nJump with both feet"
            },
            new()
            {
                ExerciseName = "Glute Bridges",
                ExerciseDescription =
                    "Lie on back, knees bent\nLift hips off ground\nSqueeze glutes at top\nLower slowly"
            },
            new()
            {
                ExerciseName = "Single-Leg Bridges",
                ExerciseDescription =
                    "Lie on back, one knee bent\nExtend other leg straight\nLift hips using bent leg\nLower with control"
            },
            new()
            {
                ExerciseName = "Calf Raises",
                ExerciseDescription = "Stand on balls of feet\nRise up onto toes\nHold briefly at top\nLower slowly"
            },
            new()
            {
                ExerciseName = "Lying Leg Lifts",
                ExerciseDescription = "Lie on side\nLift top leg up\nKeep leg straight\nLower with control"
            },
            new()
            {
                ExerciseName = "Single-Leg Deadlifts",
                ExerciseDescription =
                    "Stand on one leg\nHinge at hip, extending other leg back\nReach toward ground\nReturn to standing"
            },
            new()
            {
                ExerciseName = "Tuck Jumps",
                ExerciseDescription = "Start standing\nJump up bringing knees to chest\nLand softly\nImmediately repeat"
            },
            new()
            {
                ExerciseName = "Lateral Jumps",
                ExerciseDescription =
                    "Stand beside imaginary line\nJump sideways over line\nLand on opposite side\nJump back immediately"
            },
            new()
            {
                ExerciseName = "Skater Hops",
                ExerciseDescription =
                    "Stand on one leg\nHop laterally to other leg\nLet trailing leg cross behind\nContinue alternating"
            },
            new()
            {
                ExerciseName = "Nordic Ham Curls",
                ExerciseDescription =
                    "Kneel with feet anchored\nKeep body straight from knees up\nLower forward slowly using hamstrings\nPush back up or use hands to assist"
            },
            new()
            {
                ExerciseName = "Wall Sit",
                ExerciseDescription =
                    "Lean back against wall\nSlide down until thighs parallel to ground\nKeep knees at 90 degrees\nHold position"
            },
            new()
            {
                ExerciseName = "Jumping Jacks",
                ExerciseDescription =
                    "Start with feet together, arms at sides\nJump feet apart while raising arms overhead\nJump back to start\nRepeat continuously"
            },
            new()
            {
                ExerciseName = "Burpees",
                ExerciseDescription =
                    "Start standing\nDrop to plank position\nOptional: add push-up\nJump feet to hands, stand up"
            }
        };

        config.CoreExercises = new List<ExerciseExplanation>
        {
            new()
            {
                ExerciseName = "Knee Plank",
                ExerciseDescription =
                    "Start on hands and knees\nWalk hands forward, lower to forearms\nKeep straight line from knees to head\nHold position"
            },
            new()
            {
                ExerciseName = "Forearm Plank",
                ExerciseDescription =
                    "Start on forearms and toes\nKeep body straight from head to heels\nEngage core\nHold position"
            },
            new()
            {
                ExerciseName = "Side Plank (Knees)",
                ExerciseDescription =
                    "Lie on side, prop up on forearm\nStack knees, lift hips\nKeep body straight from knees to head\nHold position"
            },
            new()
            {
                ExerciseName = "One-Arm Plank",
                ExerciseDescription =
                    "Start in standard plank\nShift weight to one arm\nLift other arm\nKeep hips level"
            },
            new()
            {
                ExerciseName = "360° Plank",
                ExerciseDescription =
                    "Start in plank position\nWalk hands and feet in circle\nMaintain plank throughout\nComplete full rotation"
            },
            new()
            {
                ExerciseName = "Plank Shoulder Taps",
                ExerciseDescription =
                    "Start in plank position\nTap one shoulder with opposite hand\nMinimize hip rotation\nAlternate hands"
            },
            new()
            {
                ExerciseName = "Plank to Pike",
                ExerciseDescription = "Start in plank position\nLift hips up high into pike\nReturn to plank\nRepeat"
            },
            new()
            {
                ExerciseName = "Plank Jacks",
                ExerciseDescription =
                    "Start in plank position\nJump feet apart\nJump feet together\nKeep upper body stable"
            },
            new()
            {
                ExerciseName = "Dead Bugs",
                ExerciseDescription =
                    "Lie on back, arms up, knees bent 90°\nLower opposite arm and leg\nReturn to start\nAlternate sides"
            },
            new()
            {
                ExerciseName = "Bird Dogs",
                ExerciseDescription =
                    "Start on hands and knees\nExtend opposite arm and leg\nHold briefly\nReturn and switch sides"
            },
            new()
            {
                ExerciseName = "Crunches",
                ExerciseDescription =
                    "Lie on back, knees bent\nLift shoulder blades off ground\nDon't pull on neck\nLower with control"
            },
            new()
            {
                ExerciseName = "Reverse Crunches",
                ExerciseDescription =
                    "Lie on back, legs up\nLift hips off ground\nBring knees toward chest\nLower slowly"
            },
            new()
            {
                ExerciseName = "Bicycle Crunches",
                ExerciseDescription =
                    "Lie on back, hands behind head\nBring knee to opposite elbow\nExtend other leg\nAlternate sides"
            },
            new()
            {
                ExerciseName = "Russian Twists",
                ExerciseDescription =
                    "Sit with knees bent\nLean back slightly\nRotate torso side to side\nKeep chest up"
            },
            new()
            {
                ExerciseName = "Heel Taps",
                ExerciseDescription =
                    "Lie on back, knees bent\nLift shoulder blades slightly\nReach side to side tapping heels\nKeep core engaged"
            },
            new()
            {
                ExerciseName = "Leg Raises",
                ExerciseDescription =
                    "Lie on back\nKeep legs straight or slightly bent\nRaise legs to 90 degrees\nLower without touching ground"
            },
            new()
            {
                ExerciseName = "Flutter Kicks",
                ExerciseDescription =
                    "Lie on back, legs straight\nLift legs slightly off ground\nAlternate small up/down kicks\nKeep core tight"
            },
            new()
            {
                ExerciseName = "Windshield Wipers",
                ExerciseDescription =
                    "Lie on back, legs up at 90°\nLower legs to one side\nReturn to center\nLower to other side"
            },
            new()
            {
                ExerciseName = "V-Ups",
                ExerciseDescription =
                    "Lie on back, arms overhead\nSimultaneously lift legs and torso\nReach for toes\nLower with control"
            },
            new()
            {
                ExerciseName = "Hollow Hold",
                ExerciseDescription =
                    "Lie on back\nLift shoulders and legs off ground\nPress lower back to floor\nHold position"
            },
            new()
            {
                ExerciseName = "L-Sit",
                ExerciseDescription =
                    "Sit with legs extended\nPlace hands beside hips\nLift body off ground\nKeep legs parallel to floor"
            },
            new()
            {
                ExerciseName = "Cocoons",
                ExerciseDescription =
                    "Lie on back\nBring knees and chest together\nWrap arms around knees\nExtend fully, repeat"
            },
            new()
            {
                ExerciseName = "Dragon Flags",
                ExerciseDescription =
                    "Lie on bench, hold behind head\nLift entire body except shoulders\nKeep body straight\nLower slowly"
            },
            new()
            {
                ExerciseName = "Ab Wheel Rollouts",
                ExerciseDescription =
                    "Kneel holding ab wheel\nRoll forward extending body\nKeep core tight\nPull back to start"
            },
            new()
            {
                ExerciseName = "Hanging Knee Raises",
                ExerciseDescription = "Hang from bar\nLift knees to chest\nControl the movement\nLower slowly"
            },
            new()
            {
                ExerciseName = "Hanging Leg Raises",
                ExerciseDescription =
                    "Hang from bar\nKeep legs straight\nLift legs to 90° or higher\nLower with control"
            },
            new()
            {
                ExerciseName = "Toes-to-Bar",
                ExerciseDescription =
                    "Hang from bar\nLift legs up to touch bar\nUse core and hip flexors\nLower with control"
            },
            new()
            {
                ExerciseName = "Human Flag Prep",
                ExerciseDescription =
                    "Grip vertical pole\nLift body sideways\nStart with knees tucked\nHold position briefly"
            },
            new()
            {
                ExerciseName = "Human Flag",
                ExerciseDescription =
                    "Grip pole with wide hand spacing\nLift body horizontal\nKeep body straight\nHold position"
            },
            new()
            {
                ExerciseName = "Front Lever Tucks",
                ExerciseDescription = "Hang from bar\nLift knees to chest\nLean back until body parallel\nHold position"
            },
            new()
            {
                ExerciseName = "Front Lever",
                ExerciseDescription =
                    "Hang from bar\nLift body to horizontal\nKeep body completely straight\nHold position"
            },
            new()
            {
                ExerciseName = "Planche Lean",
                ExerciseDescription =
                    "Start in push-up position\nShift weight forward past hands\nRise onto toes\nHold lean position"
            },
            new()
            {
                ExerciseName = "Planche Push-ups",
                ExerciseDescription =
                    "Start in planche lean\nLower chest toward ground\nMaintain forward lean\nPush back up"
            },
            new()
            {
                ExerciseName = "L-Sit to Handstand",
                ExerciseDescription =
                    "Start in L-sit position\nRock back and kick up\nPress to handstand against wall\nLower with control"
            },
            new()
            {
                ExerciseName = "Russian Lever",
                ExerciseDescription =
                    "Lie on back\nLift legs and torso simultaneously\nCreate V-shape with body\nPulse up and down"
            },
            new()
            {
                ExerciseName = "Pike Press",
                ExerciseDescription =
                    "Start in pike position\nLower head toward ground\nPress back up\nMimics vertical pressing"
            },
            new()
            {
                ExerciseName = "Side Plank Crunch",
                ExerciseDescription = "Start in side plank\nBring top knee to elbow\nExtend back out\nKeep hips lifted"
            }
        };

        AssetDatabase.CreateAsset(config, "Assets/ProjectAssets/Settings/ExerciseDatabaseConfig.asset");
        AssetDatabase.SaveAssets();

        Debug.Log("Upper exercise config created at Assets/ExerciseDatabaseConfig.asset");
    }
}
#endif