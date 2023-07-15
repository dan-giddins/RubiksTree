using RubiksTree;

var allCubeStates = new List<CubeState>();
var solvedState = new CubeState(
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
allCubeStates.Add(solvedState);
var queue = new Queue<CubeState>();
queue.Enqueue(solvedState);
var i = 0;
while (queue.Count > 0 && i < 1000)
{
	if (i % 100 == 0)
	{
		Console.WriteLine($"{i}: {queue.Count}");
	}
	queue.Dequeue().GenAllTurns(allCubeStates, queue);
	i++;
}
var x = 0;
