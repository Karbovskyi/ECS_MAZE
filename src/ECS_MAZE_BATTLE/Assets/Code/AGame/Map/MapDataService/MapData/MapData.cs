using UnityEngine;

namespace Code.AAAGame.Map.MapService
{
    public class MapData
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        
        private readonly Cell[,] _cells;
        public MapData(int width, int height)
        {
            Width = width;
            Height = height;
            _cells = new Cell[width, height];
        }
        
        public bool TryAddWall(Vector2 wallPosition)
        {
            if (IsHasWall(wallPosition))
            {
                return false;
            }
            else
            {
                SetWallToMapData(wallPosition, true);
                return true;
            }
        }

        public void RemoveWall(Vector2 wallPosition)
        {
            SetWallToMapData(wallPosition, false);
        }

        private bool IsHasWall(Vector2 wallPosition)
        {
            Vector2Int side = MapExtensions.GetCellSide(wallPosition);
            Vector2Int cellPosition = new Vector2Int(
                Mathf.FloorToInt(wallPosition.x), 
                Mathf.FloorToInt(wallPosition.y)
            );
        
            if (side == Vector2Int.right)
            {
                return _cells[cellPosition.x, cellPosition.y].RightWall;
            }
        
            if (side == Vector2Int.left)
            {
                return _cells[cellPosition.x, cellPosition.y].LeftWall;
            }
        
            if (side == Vector2Int.down)
            {
                return _cells[cellPosition.x, cellPosition.y].DownWall;
            }
           
            if (side == Vector2Int.up)
            {
                return _cells[cellPosition.x, cellPosition.y].UpWall;
            }
        
            return false;
        }


        private void SetWallToMapData(Vector2 wallPosition, bool active)
        {
            Vector2Int side = MapExtensions.GetCellSide(wallPosition);
            Vector2Int cellPosition = new Vector2Int(
                Mathf.FloorToInt(wallPosition.x), 
                Mathf.FloorToInt(wallPosition.y)
            );
        

            if (side == Vector2Int.left)
            {
                SetLeftWall(cellPosition, active);
                return;
            }

            if (side == Vector2Int.right)
            {
                SetRightWall(cellPosition, active);
                return;
            }

            if (side == Vector2Int.down)
            {
                SetDownWall(cellPosition, active);
                return;
            }
           
            if (side == Vector2Int.up)
            {
                SetUpWall(cellPosition, active);
                return;
            }
        }

        private void SetRightWall(Vector2Int cellPosition, bool active)
        {
            _cells[cellPosition.x, cellPosition.y].RightWall = active;
            if(cellPosition.x != Width - 1)
                _cells[cellPosition.x+1, cellPosition.y].LeftWall = active;
        }

        private void SetLeftWall(Vector2Int cellPosition, bool active)
        {
            _cells[cellPosition.x, cellPosition.y].LeftWall = active;
            if(cellPosition.x != 0)
                _cells[cellPosition.x-1, cellPosition.y].RightWall = active;
        }

        private void SetDownWall(Vector2Int cellPosition, bool active)
        {
            _cells[cellPosition.x, cellPosition.y].DownWall = active;
            if(cellPosition.y != 0)
                _cells[cellPosition.x, cellPosition.y-1].UpWall = active;
        }

        private void SetUpWall(Vector2Int cellPosition, bool active)
        {
            _cells[cellPosition.x, cellPosition.y].UpWall = active;
            if(cellPosition.y != Height - 1)
                _cells[cellPosition.x, cellPosition.y+1].DownWall = active;
        }

        public void MapDebug()
        {
            for (var i0 = 0; i0 < _cells.GetLength(0); i0++)
            for (var i1 = 0; i1 < _cells.GetLength(1); i1++)
            {
                var cell = _cells[i0, i1];

                if (cell.RightWall)
                {
                    Vector3 start = new Vector3(i0 + 0.9f, 0, i1 + 0.1f);
                    Vector3 end = new Vector3(i0 + 0.9f, 0, i1 + 0.9f);
                    UnityEngine.Debug.DrawLine(start, end, Color.red);
                }
            
                if (cell.LeftWall)
                {
                    Vector3 start = new Vector3(i0 + 0.1f, 0, i1 + 0.1f);
                    Vector3 end = new Vector3(i0 + 0.1f, 0, i1 + 0.9f);
                    UnityEngine.Debug.DrawLine(start, end, Color.red);
                }
            
                if (cell.DownWall)
                {
                    Vector3 start = new Vector3(i0 + 0.1f, 0, i1 + 0.1f);
                    Vector3 end = new Vector3(i0 + 0.9f, 0, i1 + 0.1f);
                    UnityEngine.Debug.DrawLine(start, end, Color.red);
                }
            
                if (cell.UpWall)
                {
                    Vector3 start = new Vector3(i0 + 0.1f, 0, i1 + 0.9f);
                    Vector3 end = new Vector3(i0 + 0.9f, 0, i1 + 0.9f);
                    UnityEngine.Debug.DrawLine(start, end, Color.red);
                }
            }
        }
    }
}