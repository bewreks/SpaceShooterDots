using Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Aspects
{
	public readonly partial struct RotationAspect : IAspect
	{
		public readonly Entity entity;

		private readonly RefRW<LocalTransform>    _transform;
		private readonly RefRW<RotatingComponent> _rotation;

		public void RightRotation()
		{
			_rotation.ValueRW.curRotationSpeed = _rotation.ValueRO.maxRotationSpeed;
		}

		public void LeftRotation()
		{
			_rotation.ValueRW.curRotationSpeed = -_rotation.ValueRO.maxRotationSpeed;
		}

		public void StopRotation()
		{
			_rotation.ValueRW.curRotationSpeed = 0;
		}

		public void Rotate(float deltaTime)
		{
			_rotation.ValueRW.curRotation += _rotation.ValueRO.curRotationSpeed * deltaTime;
			_transform.ValueRW.Rotation   =  quaternion.Euler(0, _rotation.ValueRO.curRotation, 0);
		}
	}
}