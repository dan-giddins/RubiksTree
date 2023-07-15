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
	},
	0,
	null);
allCubeStates.Add(solvedState);
var queue = new Queue<Task>();
queue.Enqueue(solvedState.GetGenAllTurnsTask(allCubeStates, queue));
var queueItemsProcessed = 0;
while (queue.Count > 0 && queueItemsProcessed < 10000)
{
	if (queueItemsProcessed % 1 == 0)
	{
		Console.WriteLine($"{queueItemsProcessed}: {queue.Count}");
	}
	await queue.Dequeue();
	queueItemsProcessed++;
}
Console.ReadKey();
