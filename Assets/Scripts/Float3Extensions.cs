using Unity.Mathematics;

public static class Float3Extensions
{
	public static float3 MoveTowards(float3 current, float3 target, float maxDistanceDelta)
	{
		float deltaX = target.x - current.x;
		float deltaY = target.y - current.y;
		float deltaZ = target.z - current.z;
		float sqdist = deltaX * deltaX + deltaY * deltaY  + deltaZ * deltaZ ;
		if (sqdist == 0 || sqdist <= maxDistanceDelta * maxDistanceDelta)
			return target;
		var dist = math.sqrt(sqdist);
		return new float3(current.x + deltaX / dist * maxDistanceDelta,
		                  current.y + deltaY / dist * maxDistanceDelta,
		                  current.z + deltaZ / dist * maxDistanceDelta);
	}
	
	public static float3 ClampMagnitude(float3 vector, float maxLength)
	{
		float sqrMagnitude = math.lengthsq(vector);
		if (sqrMagnitude <= maxLength * maxLength)
			return vector;
		float num1 = math.sqrt(sqrMagnitude);
		float num2 = vector.x / num1;
		float num3 = vector.y / num1;
		float num4 = vector.z / num1;
		return new float3(num2 * maxLength, num3 * maxLength, num4 * maxLength);
	}
}