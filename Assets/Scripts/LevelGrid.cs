using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGrid
{
    private Vector2Int foodGridPosition, powerUpGridPosition, poisonFoodGridPosition1, poisonFoodGridPosition2;
    private GameObject foodGameObject, powerUpGameObject, poisonFoodGameObject1, poisonFoodGameObject2;
    
    private int width;
    private int height;
    
    public bool hasPowerUp;
    
    
    
   

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

        //Comprobar en que cena estamos para saber que instanciar
        if (SceneManager.GetActiveScene().name == "Game_Poison")
        {
            SpawnPoisonFood1();
            SpawnPoisonFood2();
        }
        if (SceneManager.GetActiveScene().name == "Game_PowerUp")
        {
            SpawnPowerUp();
            
        }

    }

    public bool TrySnakeEatFood(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == foodGridPosition)
        {
            
            Object.Destroy(foodGameObject);
            SpawnFood();
            
            if (SceneManager.GetActiveScene().name == "Game_Poison")
            {
                Object.Destroy(poisonFoodGameObject1);
                SpawnPoisonFood1();
                Object.Destroy(poisonFoodGameObject2);
                SpawnPoisonFood2();
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
            
            SpawnPoisonFood1();
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool TrySnakeEatPoisonFood2(Vector2Int snakeGridPosition)
    {
        if(snakeGridPosition==poisonFoodGridPosition2)
        {
            Object.Destroy(poisonFoodGameObject2);
            
            return true;
        }
        else
        {
            return false;
        }


    }
    public bool TrySnakeEatPowerUp(Vector2Int snakeGridPosition)
    {
        //si coincidimos con powerUp y bool hasPowerUp=false==>(no lo llevamos activado), lo activamos desde SnakeScript
        if (snakeGridPosition == powerUpGridPosition&& hasPowerUp==false)
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
        poisonFoodSpriteRenderer1.sprite = GameAssets_Pois.Instance.poisonFoodSprite1;
        poisonFoodGameObject1.transform.position = new Vector3(poisonFoodGridPosition1.x, poisonFoodGridPosition1.y, 0);
    }

    private void SpawnPoisonFood2()
    {
        do
        {
            poisonFoodGridPosition2 = new Vector2Int(
                Random.Range(-width / 2, width / 2),
                Random.Range(-height / 2, height / 2));
        } while (snake.GetFullSnakeBodyGridPosition().IndexOf(poisonFoodGridPosition2) != -1);

        poisonFoodGameObject2 = new GameObject("PoisonFood2");
        SpriteRenderer poisonFoodSpriteRenderer2 = poisonFoodGameObject2.AddComponent<SpriteRenderer>();
        poisonFoodSpriteRenderer2.sprite = GameAssets_Pois.Instance.poisonFoodSprite2;
        poisonFoodGameObject2.transform.position = new Vector3(poisonFoodGridPosition2.x, poisonFoodGridPosition2.y, 0);
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
        powerUpSpriteRenderer.sprite = GameAssets_PowerUp.Instance.powerUpSprite;
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
