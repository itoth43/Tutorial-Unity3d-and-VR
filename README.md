# A Unity3D and VR tutorial
## Using Game Development and VR concepts

(This page was created for the CUhackit Hackathon at Clemson University Spring of 2018)


For those interested in getting started with Unity3D and Virtual Reality.

This is a Unity3D program based on basic VR principles and fundamentals. The game topic is a "platformer" such as Super Mario Bros. The movement metaphor will be an arm swinging locomotion provided by VRTK.


## Glossary:
    - Getting Started
        - Installing and Important Files
            - Unity3D
            - Project Package Download
            - VRTK plugin
            - SteamVR plugin
        - Understanding the process and creating your Project
            - Some Initial Advice Before Starting
            - VR Principles
            - Unity Help
            - Unity Layout Description
            - Building the Environment
            - Author

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Installing and Important Files

#### Unity3D

Download and Install Unity3D:
https://unity3d.com/get-unity/download/archive

(I am using Unity3D 2017.2.0 in this tutorial)

Make sure to select the assets that you will need to port to the OS that you need whether that be Windows, Linux, or MacOS

Packages to install with initial/project install:
    - Standard Assets
    - Sample Scenes
    - Day-Night skyboxes

#### VRTK plugin


Import VRTK from the Unity3D Asset Store:
https://assetstore.unity.com/packages/tools/vrtk-virtual-reality-toolkit-vr-toolkit-64131


#### SteamVR Plugin


SteamVR SDK:
This allows the user to implement using Steams VR capabilities for the HTC Vive
https://assetstore.unity.com/packages/templates/systems/steamvr-plugin-32647

(I specify this as it is what I am using for my implementation)


### Understanding the Process and Creating your Project

This section will follow the process of creating the above project as well as important VR concepts to keep in mind.

I will be using the term "asset" to refer to all objects unless specific terms are required.

#### Some Initial Advice:

    - Start Small.
    - Come up with 3 to 4 ideas, then ask yourself which of them is within the scope of your time and resources?
    - Don't reinvent the wheel if you don't need to. Use the Asset store.
    - TEST OFTEN. If you build the entire project then test it, you will likely end up with a lot of errors and warnings.
    - Write and draw out your project before you even touch any code. You will make much better decisions when you have a clear idea in mind.
    - Keep your project clean and organized
    - Shoot to build something that you may not be able to do outside of VR.
    - Don't worry so much about graphics, the users imagination is great at filling in the rest if you follow the VR Principles and make it immersive.

#### VR Principles

    - Create an Immersive Environment using Technology that lets it respond to you
        - "Do I interact with the environment? How? How much?"
    - Choose Movement Metaphor ~ including but not limited to the following:

        - Teleportation
        - Locomotion
        - Stationary
        - Moving Platform
        - Vehicle

    - Keep the project Clean and Fast (Optimize and don't sacrifice Frame Rate)
    - First Person point of view
    - Storytelling ~ this will be established by using the above principles
        - This doesn't mean that you need a story to the content but that you want your project to make the user feel like they are one with the world you have made.

#### Unity Help

Know your hotkeys to be quicker in the editor. This will take time but is very much worth it,

Link to hotkeys list: https://docs.unity3d.com/Manual/UnityHotkeys.html)

Use the forums for help and inspiration if needed,
Link to Unity3D forums homepage: https://forum.unity.com

and of course remember that GOOGLE is your friend and is great for finding your answers but will probably lead you back to the forum pages.

#### Layout

Scene Window

    - The manipulable view of your project, you can drag assets into this window to move them into the view.
    - Translations, Transformations, Scaling, Adding and Destroying can be done in this window.

Game Window

    - The project from the point of view of the main camera in use.
    - Different aspect ratios can be chosen
    - Stats can be viewed Here
    - Other settings are here as well but far less used in this Project

Hierarchy Panel

    - This panel contains the assets that can be seen in the Scene and Game windows.
    - This panel is connected to the "Inspector". We will talk about the Inspector further below

Project Panel

    - Contains all assets downloaded into your project but are not directly in use in the Scene and Game Windows.
    - Here is where you can make assets whether it be by dragging audio, images, assets (into the panel from outside the Unity project), or by dragging in custom assets built in the Scene/Game Windows from the Hierarchy panel.
    - Anything in this panel can be dragged into the Hierarchy panel or Scene/Game window to be used in game.

Inspector

    - Here you can see a more detailed breakdown of an asset.
    - You can manipulate the assets that are seen in the Hierarchy or Project panels.
    - You can add components (examples: audio sources, scripts, light sources, etc.)
        - components could also be known as assets that are attached to other assets (this concept should not be confused with the parent/child relationship).

Console Window

    - Here you can see:
        - Debug Log output
        - Compile/runtime warnings
        - Compile/runtime errors

#### Building the Environment

All shapes referenced and used are Unity3D native shapes.

HOW-TO:
Asset can be placed in the scene or created in a number of ways:

    - From the "GameObjects" tab on the top of the editor.
    - Clicking the drop down "Create" tab on the Hierarchy panel (to create a new asset click the "Create" dropdown in the Project panel).
    - Using prefabs in the Project panel.

They can then be manipulated by:

    - Translating
    - Transforming
    - Scaling

0) Character Controller

    - Drag a VRTK prefab player controller into the Hierarchy Panel. Our world will be built around this controller. (The custom one used in my scene can be found in the folder named "Resources").

1) Static Environment

    Static elements (How they were made):


    - Walking Grounds: cubes with a texture (provided or found through a free source online).
    - Grassy fields: 2 cubes with textures. Stretch them to your favored size while keeping a gap in the middle for the Walking grounds.
        - The hills are capsules with the grass texture applied.
        - The trees are 2 capsules stacked at different heights and sizes to get a tree looks with applied grass and bark textures.
    - Boundaries: 2 boxes are placed on either sides of the Walking Grounds with there mesh components disabled in order to only make use of the Colliders (https://docs.unity3d.com/Manual/CollidersOverview.html).
    - Tree bridges: just the trunk of the trees we made before
    - Castle: This is made up of cubes and the Walking Ground textures


    Interactive elements (Explaining important Unity elements):


    - Floating Coin: Found in the walk ways

        - C# script: "OnTriggerCollect"
            - Uses the trigger checkbox on the coins collider when coming in contact with another collider who's tag is "Player" or "hand"
            - The number of your coin int variable (in the manager script that is attached to the Scene_manager object) will increase by one
            - The coin object will be destroyed
                - This all falls under the immersive idea that you have "collected" the coin
        - C# script: "VerticalPlatform"
            - has a "pingpong" function that allows the object to vertically move back and forth between 0 and Height
            - Allows for adjustable Speed
            - Offset controls the manipulated coordinate value's distance from 0
        - Trigger enabled Collider
        - Plays sound when coming in contact


    - Falling Coin: Dropped by enemies when knocked out

        - C# script: "OnTriggerCollect" (see above)
        - Rigidbody to allow for gravity
        - Trigger enabled Collider
        - Plays sound when coming in contact


    - Bad Guy: Roaming the walk ways

        - C# script: "Horizontal Platform"
            - same as the vertical platform script, just moving horizontally
        - C# script: "OnTriggerKill" (works like the collecting script)
            - This will instantiate (https://docs.unity3d.com/ScriptReference/Object.Instantiate.html) a falling coin
            - The bad guy will then be destroyed
        - Trigger enabled Collider
        - Plays sound when coming in contact


    - Lifting Brick platform: found in the walk ways

        - C# script: "Vertical Platform" (see above)


    - Pits: found in the walk ways
        - C# script: "OnTriggerDeath" (works like "OnTriggerKill")

            - This will move the player controller back to start
            - subtracts from the lives int variable on the manager script
            - Plays sound when coming in contact


    Lighting in Environment (Concepts):

    - Make sure that your light source matches the tone of the scene and the skybox (if you have setup a skybox).
    - The intensity refers to how bright the scene is, this and the color are important to get right as it helps define the immersion of the Scene.
    - Options for shadows can be kept to soft or none as this is heavy on rendering and may hold back your potential positive frame rate
        - These and other quality settings can be found under Edit -> Project Settings -> Graphics


    Scripting for Assets (Summary):

    - (It is assumed that you have had some scripting/coding experience. If you have not, there are plenty of tutorial for that on Youtube).

    - Most of the custom scripts are explained in the above section, if you want to know how the VRTK scripts work please reference their documentation: (https://vrtoolkit.readme.io)

    - The custom scripts made for this project specifically are documented by line.


    Feel free to email me about this code if you have any questions.  


    Scene Manager (Concept):

    The Scene Manager is used to control important variables and/or functions used throughout your entire project.

    Canvas and UI (Concept and Reference):

    You'll see the most important part in VR with UI is that it isn't obstructive.

    See the settings in the Inspector for the Canvas used in the project scene that the "Render Mode" is set to World Space. This will keep the UI from being locked to the main camera.


## Authors

* **Isaiah Toth**

A Software Consultant/Engineer and Clemson University Graduate 2018.


Isaiah Toth is the youngest in a big family from a small town in north east Ohio. He is a Senior Computer Science student at Clemson University where he spends most of his time working with machine learning, web development and virtual reality. He has worked with several teams on big projects and some even winning awards for their work.

Since the his first year at Clemson he has worked full time jobs holding titles like Lieutenant of the student police, software developing Intern, Housing manager for the University, and more. Most of these jobs included instructing, training, and managing 15-30 other workers. He is always working to achieve his goal of using his abilities to help others. Isaiah enjoys creating art through forms of writing, sketching, and programming.

Isaiah is always looking for new opportunities to grow in the software engineering community and chances to share his experiences with others.
