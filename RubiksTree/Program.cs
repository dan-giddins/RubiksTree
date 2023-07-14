using RubiksTree;
var allCubeStates = new List<CubeState>();
var baseState = new CubeState(
	new FaceColour[,,]
	{
		{
			{ FaceColour.White, FaceColour.White },
			{ FaceColour.White, FaceColour.White }
		},
		{
			{ FaceColour.Red, FaceColour.Red },
			{ FaceColour.Red, FaceColour.Red }
		},
		{
			{ FaceColour.Yellow, FaceColour.Yellow },
			{ FaceColour.Yellow, FaceColour.Yellow }
		},
		{
			{ FaceColour.Orange, FaceColour.Orange },
			{ FaceColour.Orange, FaceColour.Orange }
		},
		{
			{ FaceColour.Blue, FaceColour.Blue },
			{ FaceColour.Blue, FaceColour.Blue }
		},
		{
			{ FaceColour.Green, FaceColour.Green },
			{ FaceColour.Green, FaceColour.Green }
		}
});
allCubeStates.Add(baseState);
var queue = new Queue<CubeState>();
queue.Enqueue(baseState);
var i = 0;
while (queue.Count > 0)
{
	if (i % 100 == 0)
	{
		Console.WriteLine($"{i}: {queue.Count}");
	}
	queue.Dequeue().GenAllTurns(allCubeStates, queue);
	i++;
}
var x = 0;