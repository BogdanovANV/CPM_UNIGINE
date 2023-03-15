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

[Component(PropertyGuid = "22a7074b4225342e839aedb5dcb02390189c21af")]
public class visual : Component
{
	public bool state = false;//состояние
	public dvec3 loc;//переменная для запоминания позиции

	private void Init()
	{
		// write here code to be called on component initialization
		loc = node.Position;
	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		if (Input.IsKeyUp(Input.KEY.F))
		{
			if (state == false)

			{
				node.Position = new Vec3(-100.0f, -100.0f, -100.0f);
				state = true;
			}else
			{
				node.Position = loc;
				state = false;
			}
		}
	}
}