using Unity.Entities;

namespace Components
{
	public struct MovingComponent : IComponentData,
	                                IEnableableComponent
	{
		public float acceleration;
		public float curAcceleration;
	}
}