This mod does nothing on it's own, it may be a requirement for other mods though...

# DOCUMENTATION:
This documentation will show you how to use the stilt modding api correctly.

# EVENTS:
There are some custom events that will give useful data...
There is only one current event in the release version, but you can type `StiltEventHandler.` and it will give a list of every custom event that can be used, and a description on what they do.

Lets first go ahead and check when the player joins a scene that is either a multiplayer scene, or contains the player prefab!
first, remember to add `using StiltModdingAPI.Behaviours.Events;`.
You can do the following to subscribe to the event using the StiltEventHandler class:
```CS
        void Awake() =>
            //Sub to the event with "+="
            StiltEventHandler.OnSceneLoaded += OnNewSceneLoaded;

        //This method runs when the new scene is loaded
        void OnNewSceneLoaded(bool ContainsPlayerPrefab, bool IsMultiplayerScene) {
            //runs when any scene is loaded.

            if (ContainsPlayerPrefab) {
                //code runs here if the scene that is loaded contains the player prefab. This should be used for scenes that require button inputs or for opening a menu on your hand.
            }

            if(IsMultiplayerScene) {
                //code runs here if the scene that is loaded is a multiplayer scene.
            }
        }
```

# CUSTOM POWERUPS:
pl2w pls add documentation here, I have no idea how your custom powerups thing works :P
sorry to anyone for any inconvenience

# INPUTS:
first, remember to add `using StiltModdingAPI.StiltInputs;`.
Controller inputs are as easy as doing:
```CS
        void Update() {
            //using left trigger as an example
            if (Inputs.LeftTriggerDown)
                Debug.Log("left trigger pressed");
        }
```
That's all... uh, bye!
