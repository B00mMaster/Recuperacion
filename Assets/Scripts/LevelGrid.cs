using UnityEngine;

public class LevelGrid
{
    private Vector2Int foodGridPosition, powerUpGridPosition, poisonFoodGridPosition1;
    private GameObject foodGameObject, powerUpGameObject, poisonFoodGameObject1;
    
    private int width;
    private int height;

    public bool hasPowerUp;
    public bool hasPoisonFood1;

    private Snake snake;

    public LevelGrid(int w, int h)
    {
        width = w;
        height = h;
    }

    public void Setup(Snake snake)
    {
        this.snake = snake;
        SpawnFood();
        SpawnPowerUp();
    }

    public bool TrySnakeEatFood(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == foodGridPosition)
        {
            Object.Destroy(foodGameObject);
            SpawnFood();
            Object.Destroy(poisonFoodGameObject1);
           
            if(hasPoisonFood1==false)
            {
                SpawnPoisonFood1();
            }

            Score.AddScore(Score.POINTS);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool TrySnakeEatPoisonFood1(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == poisonFoodGridPosition1)
        {
            Object.Destroy(poisonFoodGameObject1);
            hasPoisonFood1 = true;
           
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool TrySnakeEatPowerUp(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == powerUpGridPosition&& hasPowerUp==false && GameManager.levelPU==true)
        {
            Object.Destroy(powerUpGameObject);
            SpawnPowerUp();
            
           
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SpawnFood()
    {
        // while (condicion){
        // cosas
        // }
        
        // { cosas }
        // while (condicion)
        
        do
        {
            foodGridPosition = new Vector2Int(
                Random.Range(-width / 2, width / 2),
                Random.Range(-height / 2, height / 2));
        } while (snake.GetFullSnakeBodyGridPosition().IndexOf(foodGridPosition) != -1);
        
        foodGameObject = new GameObject("Food");
        SpriteRenderer foodSpriteRenderer = foodGameObject.AddComponent<SpriteRenderer>();
        foodSpriteRenderer.sprite = GameAssets.Instance.foodSprite;
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y, 0);
    }

    private void SpawnPoisonFood1()
    {
        do
        {
            poisonFoodGridPosition1 = new Vector2Int(
                Random.Range(-width / 2, width / 2),
                Random.Range(-height / 2, height / 2));
        } while (snake.GetFullSnakeBodyGridPosition().IndexOf(poisonFoodGridPosition1) != -1);

        poisonFoodGameObject1 = new GameObject("PoisonFood1");
        SpriteRenderer poisonFoodSpriteRenderer1 = poisonFoodGameObject1.AddComponent<SpriteRenderer>();
        poisonFoodSpriteRenderer1.sprite = GameAssets.Instance.poisonFoodSprite1;
        poisonFoodGameObject1.transform.position = new Vector3(poisonFoodGridPosition1.x, poisonFoodGridPosition1.y, 0);
    }

    private void SpawnPowerUp()
    {
        do
        {
            powerUpGridPosition = new Vector2Int(
                Random.Range(-width / 2, width / 2),
                Random.Range(-height / 2, height / 2));
        } while (snake.GetFullSnakeBodyGridPosition().IndexOf(powerUpGridPosition) != -1);

        powerUpGameObject = new GameObject("PowerUp");
        SpriteRenderer powerUpSpriteRenderer = powerUpGameObject.AddComponent<SpriteRenderer>();
        powerUpSpriteRenderer.sprite = GameAssets.Instance.powerUpSprite;
        powerUpGameObject.transform.position = new Vector3(powerUpGridPosition.x, powerUpGridPosition.y, 0);
    }

    public Vector2Int ValidateGridPosition(Vector2Int gridPosition)
    {
        int w = Half(width);
        int h = Half(height);
        
        // Me salgo por la derecha
        if (gridPosition.x > w)
        {
            gridPosition.x = -w;
        }
        if (gridPosition.x < -w)
        {
            gridPosition.x = w;
        }
        if (gridPosition.y > h)
        {
            gridPosition.y = -h;
        }
        if (gridPosition.y < -h)
        {
            gridPosition.y = h;
        }

        return gridPosition;
    }

    private int Half(int number)
    {
        return number / 2;
    }
}
