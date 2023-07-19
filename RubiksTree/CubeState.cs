namespace RubiksTree;
internal class CubeState
{
	// front, right, back, left, top, bottom
	public readonly FaceColour[,,] Faces;
	public CubeState? TurnBottomCubeState;
	public CubeState? TurnRightCubeState;
	public CubeState? TurnBackCubeState;
#pragma warning disable IDE0052 // Remove unread private members
	public readonly CubeState? SolutionMove;
#pragma warning restore IDE0052 // Remove unread private members
	public readonly int Depth;

	public CubeState(FaceColour[,,] faces, int depth, CubeState? solutionMove)
	{
		Faces = faces;
		Depth = depth;
		SolutionMove = solutionMove;
	}

	private FaceColour[,,] DeepCopyFaces()
	{
		var result = new FaceColour[Faces.GetLength(0), Faces.GetLength(1), Faces.GetLength(2)];
		Array.Copy(Faces, result, Faces.Length);
		return result;
	}

	public Task GetGenAllTurnsTask(IList<CubeState> allCubeStates, Queue<Task> queue) =>
		new(() => GenAllTurns(allCubeStates, queue));

	public void GenAllTurns(IList<CubeState> allCubeStates, Queue<Task> queue)
	{
		var turnBottomFacesTemp = DeepCopyFaces();
		turnBottomFacesTemp[0, 1, 0] = Faces[1, 1, 0];
		turnBottomFacesTemp[0, 1, 1] = Faces[1, 1, 1];
		turnBottomFacesTemp[1, 1, 0] = Faces[2, 1, 0];
		turnBottomFacesTemp[1, 1, 1] = Faces[2, 1, 1];
		turnBottomFacesTemp[2, 1, 0] = Faces[3, 1, 0];
		turnBottomFacesTemp[2, 1, 1] = Faces[3, 1, 1];
		turnBottomFacesTemp[3, 1, 0] = Faces[0, 1, 0];
		turnBottomFacesTemp[3, 1, 1] = Faces[0, 1, 1];

		turnBottomFacesTemp[5, 0, 0] = Faces[5, 0, 1];
		turnBottomFacesTemp[5, 0, 1] = Faces[5, 1, 1];
		turnBottomFacesTemp[5, 1, 1] = Faces[5, 1, 0];
		turnBottomFacesTemp[5, 1, 0] = Faces[5, 0, 0];

		var turnBottomFaces = DeepCopyFaces();
		turnBottomFaces[0, 1, 0] = turnBottomFacesTemp[1, 1, 0];
		turnBottomFaces[0, 1, 1] = turnBottomFacesTemp[1, 1, 1];
		turnBottomFaces[1, 1, 0] = turnBottomFacesTemp[2, 1, 0];
		turnBottomFaces[1, 1, 1] = turnBottomFacesTemp[2, 1, 1];
		turnBottomFaces[2, 1, 0] = turnBottomFacesTemp[3, 1, 0];
		turnBottomFaces[2, 1, 1] = turnBottomFacesTemp[3, 1, 1];
		turnBottomFaces[3, 1, 0] = turnBottomFacesTemp[0, 1, 0];
		turnBottomFaces[3, 1, 1] = turnBottomFacesTemp[0, 1, 1];

		turnBottomFaces[5, 0, 0] = turnBottomFacesTemp[5, 0, 1];
		turnBottomFaces[5, 0, 1] = turnBottomFacesTemp[5, 1, 1];
		turnBottomFaces[5, 1, 1] = turnBottomFacesTemp[5, 1, 0];
		turnBottomFaces[5, 1, 0] = turnBottomFacesTemp[5, 0, 0];
		TurnBottomCubeState = ProcessFaces(turnBottomFaces, TurnBottomCubeState, allCubeStates, queue);
		TurnBottomCubeState.TurnBottomCubeState = this;

		var turnRightFacesTemp = DeepCopyFaces();
		turnRightFacesTemp[0, 0, 1] = Faces[4, 0, 1];
		turnRightFacesTemp[0, 1, 1] = Faces[4, 1, 1];
		turnRightFacesTemp[4, 0, 1] = Faces[2, 1, 0];
		turnRightFacesTemp[4, 1, 1] = Faces[2, 0, 0];
		turnRightFacesTemp[2, 0, 0] = Faces[5, 1, 1];
		turnRightFacesTemp[2, 1, 0] = Faces[5, 0, 1];
		turnRightFacesTemp[5, 0, 1] = Faces[0, 0, 1];
		turnRightFacesTemp[5, 1, 1] = Faces[0, 1, 1];
		turnRightFacesTemp[1, 0, 0] = Faces[1, 0, 1];
		turnRightFacesTemp[1, 0, 1] = Faces[1, 1, 1];
		turnRightFacesTemp[1, 1, 1] = Faces[1, 1, 0];
		turnRightFacesTemp[1, 1, 0] = Faces[1, 0, 0];

		var turnRightFaces = DeepCopyFaces();
		turnRightFaces[0, 0, 1] = turnRightFacesTemp[4, 0, 1];
		turnRightFaces[0, 1, 1] = turnRightFacesTemp[4, 1, 1];
		turnRightFaces[4, 0, 1] = turnRightFacesTemp[2, 1, 0];
		turnRightFaces[4, 1, 1] = turnRightFacesTemp[2, 0, 0];
		turnRightFaces[2, 0, 0] = turnRightFacesTemp[5, 1, 1];
		turnRightFaces[2, 1, 0] = turnRightFacesTemp[5, 0, 1];
		turnRightFaces[5, 0, 1] = turnRightFacesTemp[0, 0, 1];
		turnRightFaces[5, 1, 1] = turnRightFacesTemp[0, 1, 1];
		turnRightFaces[1, 0, 0] = turnRightFacesTemp[1, 0, 1];
		turnRightFaces[1, 0, 1] = turnRightFacesTemp[1, 1, 1];
		turnRightFaces[1, 1, 1] = turnRightFacesTemp[1, 1, 0];
		turnRightFaces[1, 1, 0] = turnRightFacesTemp[1, 0, 0];
		TurnRightCubeState = ProcessFaces(turnRightFaces, TurnRightCubeState, allCubeStates, queue);
		TurnRightCubeState.TurnRightCubeState = this;

		var turnBackFacesTemp = DeepCopyFaces();
		turnBackFacesTemp[1, 0, 1] = Faces[5, 1, 1];
		turnBackFacesTemp[1, 1, 1] = Faces[5, 1, 0];
		turnBackFacesTemp[4, 0, 0] = Faces[1, 0, 1];
		turnBackFacesTemp[4, 0, 1] = Faces[1, 1, 1];
		turnBackFacesTemp[3, 0, 0] = Faces[4, 0, 1];
		turnBackFacesTemp[3, 1, 0] = Faces[4, 0, 0];
		turnBackFacesTemp[5, 1, 0] = Faces[3, 0, 0];
		turnBackFacesTemp[5, 1, 1] = Faces[3, 1, 0];
		turnBackFacesTemp[2, 0, 0] = Faces[2, 1, 0];
		turnBackFacesTemp[2, 1, 0] = Faces[2, 1, 1];
		turnBackFacesTemp[2, 1, 1] = Faces[2, 0, 1];
		turnBackFacesTemp[2, 0, 1] = Faces[2, 0, 0];

		var turnBackFaces = DeepCopyFaces();
		turnBackFaces[1, 0, 1] = turnBackFacesTemp[5, 1, 1];
		turnBackFaces[1, 1, 1] = turnBackFacesTemp[5, 1, 0];
		turnBackFaces[4, 0, 0] = turnBackFacesTemp[1, 0, 1];
		turnBackFaces[4, 0, 1] = turnBackFacesTemp[1, 1, 1];
		turnBackFaces[3, 0, 0] = turnBackFacesTemp[4, 0, 1];
		turnBackFaces[3, 1, 0] = turnBackFacesTemp[4, 0, 0];
		turnBackFaces[5, 1, 0] = turnBackFacesTemp[3, 0, 0];
		turnBackFaces[5, 1, 1] = turnBackFacesTemp[3, 1, 0];
		turnBackFaces[2, 0, 0] = turnBackFacesTemp[2, 1, 0];
		turnBackFaces[2, 1, 0] = turnBackFacesTemp[2, 1, 1];
		turnBackFaces[2, 1, 1] = turnBackFacesTemp[2, 0, 1];
		turnBackFaces[2, 0, 1] = turnBackFacesTemp[2, 0, 0];
		TurnBackCubeState = ProcessFaces(turnBackFaces, TurnBackCubeState, allCubeStates, queue);
		TurnBackCubeState.TurnBackCubeState = this;
	}

	private CubeState ProcessFaces(
		FaceColour[,,] faces,
		CubeState? cubeState,
		IList<CubeState> allCubeStates,
		Queue<Task> queue)
	{
		cubeState = GetCubeStateIfExists(faces, allCubeStates, cubeState);
		if (cubeState is null)
		{
			cubeState = CreateNewCubeState(faces, allCubeStates);
			var task = cubeState.GetGenAllTurnsTask(allCubeStates, queue);
			lock (queue)
			{
				queue.Enqueue(task);
			}
		}
		return cubeState;
	}

	private static CubeState? GetCubeStateIfExists(FaceColour[,,] inputFaces, IList<CubeState> allCubeStates, CubeState? cubeState)
	{
		if (cubeState is not null)
		{
			return cubeState;
		}
		for (var i = 0; i < allCubeStates.Count; i++)
		{
			var testCubeState = allCubeStates[i];
			if (AreFacesEqual(inputFaces, testCubeState?.Faces))
			{
				return testCubeState;
			}
		}
		return null;
	}

	private static bool AreFacesEqual(FaceColour[,,] inputFaces, FaceColour[,,]? testFaces)
	{
		if (testFaces is null)
		{
			return false;
		}
		var inputFacesEnumerator = inputFaces.GetEnumerator();
		var testFacesEnumerator = testFaces.GetEnumerator();
		while (inputFacesEnumerator.MoveNext())
		{
			_ = testFacesEnumerator.MoveNext();
			if ((FaceColour)inputFacesEnumerator.Current != (FaceColour)testFacesEnumerator.Current)
			{
				return false;
			}
		}
		return true;
	}

	private CubeState CreateNewCubeState(FaceColour[,,] faces, IList<CubeState> allCubeStates)
	{
		var cubeState = new CubeState(faces, Depth + 1, this);
		allCubeStates.Add(cubeState);
		return cubeState;
	}
}
