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
var queue = new Queue<Action>();
var action = solvedState.GetGenAllTurnsAction(allCubeStates, queue);
lock (queue)
{
	queue.Enqueue(action);
}
var queueItemsProcessed = 0;
while (queueItemsProcessed < 100000)
{
	if (queueItemsProcessed % 1000 == 0)
	{
		Console.WriteLine($"{queueItemsProcessed}: {queue.Count}");
	}
	//await Task.Run(queue.Dequeue());
	//queueItemsProcessed++;
	bool gotItem;
	lock (queue)
	{
		gotItem = queue.TryDequeue(out action);
	}
	if (gotItem && action is not null)
	{
		_ = Task.Run(action);
		queueItemsProcessed++;
	}
}
Console.WriteLine("Done.");
var groupedStates = allCubeStates.GroupBy(x => x.Depth);
Console.ReadKey();
