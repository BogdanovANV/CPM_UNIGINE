using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "f2eafd0ce95c94fb8601861ebee0b6e553147b00")]
public class richText : Component
{
	private void Init()
	{
		// write here code to be called on component initialization
		
	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		node.WorldLookAt(Game.Player.WorldPosition);
		// Rotate text a little bit so it shows up properly
		node.Rotate(0, 0, 0);
	}
}