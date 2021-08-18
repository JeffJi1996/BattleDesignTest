----------------------------------------
PARTICLE LOGO FX
----------------------------------------

1. Introduction
2. Adding your logo
3. Scaling the logo
4. Finalizing the effect
5. Bloom & Post-Processing
6. Contact

----------------------------------------
1. INTRODUCTION
----------------------------------------

Particle Logo FX includes 30 scenes of different themed logo particle effects which will start playing once the scene is running. These scenes can be useful as an intro-screen or a menu screen with the title of your game.

Each scene is made up from 4 main elements:

A) The QuadLogo which is simply a Quad with a logo material. In the 'LogoFadeIn' scenes, this will be animated to fade in. There are 3 animation speeds included, an Instant pop-in animation, Fast and Slow fade-ins.

B) One or several Particle Systems which (most of them) emit particles by referring to a logo texture file.

C) The Scene prefab. This contains a simple Camera with a Post Processing Behavior script. Note that changing the prefab in the Project folder will adjust it in each of the 30 scenes included.

D) The CanvasSceneSelect which is a simple GUI of buttons that lets you browse through the different scenes once you've added them to Build Settings.

----------------------------------------
2. ADDING YOUR LOGO
----------------------------------------

The simplest way to use your logo in the scenes of the asset is to edit the default PNG logo file in a image editing app such as Photoshop, erase the contents and import your own logo.

Alternatively you can overwrite the original PNG file with a logo texture in the same square proportions. If you supply a logo texture in a rectangular resolution, the texture will be wrongly stretched on the Quad in the scene.

Once your logo texture is in place, make sure that 'Read/Write Enabled' is enabled in the texture settings, or else you may have bad results when you try to view the effect in a build.

----------------------------------------
3. SCALING THE LOGO
----------------------------------------

Changing the scale of the effect/logo can be done in two ways:

A) Simply scale the parent effect which contains the QuadLogo and other effects in Transform. You can either use the default Scaling tool (Hotkey 'R'), or you can select the parent effect and type in the Scale in Transform manually.

B) Locate the Camera in the 'Scene' prefab and adjust the Size. This will adjust how much space the camera is covering.

----------------------------------------
4. FINALIZING THE EFFECT
----------------------------------------

Now that your logo is in place and scaled to your liking, you will want to simply delete the 'CanvasSceneSelect' from your scene.

Other finishing touches you can do to customize your logo scene is to experiment with the Background color. Select the Camera in the Scene prefab and customize the Background color. The default color is a dark blue color.

----------------------------------------
5. BLOOM & POST PROCESSING
----------------------------------------

In order to view the glowy effects of emission in the particles, make sure that you find a post processing solution that supports Bloom.

For earlier versions of Unity, you can find a Post-Processing Stack on the Unity Asset Store, or in later versions, a Post-Processing solution is available in the Package Manager.

Available media of the asset has been recorded with Antialiasing, Bloom and Vignette enabled.

----------------------------------------
6. CONTACT
----------------------------------------

Twitter: @archanor
Support: archanor.work@gmail.com

For support or criticism, please contact me over e-mail.

Follow me and my work on Twitter for updates and new VFX assets.

Ratings & reviews are much appreciated!

----------------------------------------

Made by Kenneth "Archanor" Foldal Moe
