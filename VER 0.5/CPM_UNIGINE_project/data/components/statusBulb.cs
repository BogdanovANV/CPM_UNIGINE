using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

#if UNIGINE_DOUBLE
using Vec3 = Unigine.dvec3;
using Vec4 = Unigine.dvec4;
using Mat4 = Unigine.dmat4;
#else
    using Vec3 = Unigine.vec3;
    using Vec4 = Unigine.vec4;
    using Mat4 = Unigine.mat4;
#endif 

[Component(PropertyGuid = "37ea2e86ecf2b42d90f107a8612146e759ee971a")]
public class statusBulb : Component
{

	public int wst = 0;
	public Node rd;
	public Node gr;
	public Node bl;

	public dvec3 locrd;
	public dvec3 locgr;
	public dvec3 locbl;
	

	private void stat()
	{
		if (wst==1)
		{
			
			bl.Position = new Vec3(-100.0f, -100.0f, -100.0f);
			gr.Position = new Vec3(-100.0f, -100.0f, -100.0f);
			rd.Position = locrd;
			
		}
		if (wst==2)
		{
			
			rd.Position = new Vec3(-100.0f, -100.0f, -100.0f);
			gr.Position = new Vec3(-100.0f, -100.0f, -100.0f);
			bl.Position = locbl;
			
		}
		if (wst==3)
		{
			
			bl.Position = new Vec3(-100.0f, -100.0f, -100.0f);
			rd.Position = new Vec3(-100.0f, -100.0f, -100.0f);
			gr.Position = locgr;
			
		}
	}
	

	private void Init()
	{
		// write here code to be called on component initialization
		locrd = rd.Position;
		locgr = gr.Position;
		locbl = bl.Position;
		
	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		if (Input.IsKeyUp(Input.KEY.NUMPAD_DIGIT_1))
		{
			wst = 1;
			stat();
		}
		if (Input.IsKeyUp(Input.KEY.NUMPAD_DIGIT_2))
		{
			wst = 2;
			stat();
		}
		if (Input.IsKeyUp(Input.KEY.NUMPAD_DIGIT_3))
		{
			wst = 3;
			stat();
		}
		
	}
}