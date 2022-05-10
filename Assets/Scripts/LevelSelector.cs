using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] GameObject _levelButtonPrefab;
    [SerializeField] Canvas _canvas;

    [SerializeField] int rows = 3;
    [SerializeField] int columns = 10;

    [Range(0, 100)][SerializeField] float xMarginPercentage = 8;
    [Range(0, 100)][SerializeField] float yMarginPercentage = 10;

    private GameObject[,] _allLevels;

    private float _canvasWidth;
    private float _canvasHeight;

    private void Awake()
    {
        RectTransform _canvasTransform = _canvas.GetComponent<RectTransform>();
        _canvasWidth = _canvasTransform.rect.width * _canvasTransform.localScale.x;
        _canvasHeight = _canvasTransform.rect.height * _canvasTransform.localScale.y;
    }

    private void Start()
    {
        int levelNumber = SceneManager.sceneCountInBuildSettings - 2;
        int levelCounter = 0;
        _allLevels = new GameObject[rows, columns];

        int _levelReached = PlayerPrefs.GetInt("levelReached", 1);

        float xMargin = (xMarginPercentage / 100) * _canvasWidth;
        float yMargin = (yMarginPercentage / 100) * _canvasHeight;

        float xInitialSpawnPos = xMargin + xMargin/2;
        float yInitialSpawnPos = _canvasHeight - yMargin - 
            (_levelButtonPrefab.GetComponent<RectTransform>().rect.height / 2 *
            _levelButtonPrefab.GetComponent<RectTransform>().localScale.y);
        Vector3 spawnPos = new Vector3(xInitialSpawnPos , yInitialSpawnPos , 0);

        bool allLevelsInPlace = false;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (levelCounter >= levelNumber) { allLevelsInPlace = true; break; }

                _allLevels[i, j] = Instantiate(_levelButtonPrefab, spawnPos, Quaternion.identity);
                _allLevels[i, j].gameObject.transform.SetParent(transform);
                _allLevels[i, j].GetComponent<LevelButton>().index = levelCounter + 1;

                ApplyCorrectScale(_allLevels[i, j]);

                _allLevels[i, j].gameObject.transform.GetComponentInChildren<TextMeshProUGUI>().text = (levelCounter + 1).ToString();

                if (levelCounter + 1 > _levelReached) { _allLevels[i, j].GetComponent<Button>().interactable = false; }

                spawnPos.x += (_canvasWidth - xMargin * 2) / columns;
                
                levelCounter++;
            }

            if (allLevelsInPlace) { break; }

            spawnPos.x = xInitialSpawnPos;
            spawnPos.y -= (_canvasHeight - yMargin * 4) / rows;
        }
        transform.localPosition = new Vector3(2000, 0);
    }

    void ApplyCorrectScale(GameObject level)
    {
        level.GetComponent<RectTransform>().localScale = _levelButtonPrefab.GetComponent<RectTransform>().localScale;
    }
}
