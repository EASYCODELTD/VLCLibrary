# VLCLibrary

VLCLibrary is C# wraper to VLC Library

Compatible with:

*  VLC 2.1.5
*  Mono/.NET 4.5 (linux/windows)


![GitHub Logo](https://www.gnu.org/graphics/lgplv3-147x51.png)
Licence: https://www.gnu.org/licenses/lgpl.html

## Example

``` C#

	LibVLC lib = new LibVLC ();
	Gtk.Image image = // Any gui IMAGE 
	VLCMedia media = lib.CreateMediaFromPath ("media.mp4");
	VLCMediaPlayer player = lib.CreatePlayer (media);
	player.SetDrawable(image);
	player.Play();

```

Or just use a VLCWidget

