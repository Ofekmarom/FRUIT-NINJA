# משחק fruit ninja

## תיאור המשחק
במטלה זאת יצרתי את המשחק fruit ninja שזה משחק פשוט ומהנה. השחקן משתמש בעכבר כדי לחתוך אבטיחים הקופצים על המסך. כאשר חותכים אבטיח, הוא מתפצל לשני חלקים שנעלמים לאחר מספר שניות. המטרה היא לחתוך כמה שיותר אבטיחים.

---

## תכונות המשחק
1. **חיתוך אבטיחים:**
   - השחקן יכול לחתוך אבטיחים באמצעות תנועת העכבר.
   - האבטיח שנחתך מתפצל לשני חלקים שמתפזרים.

2. **תנועת האבטיחים:**
   - האבטיחים משוגרים מהלמטה של המסך עם כוח כלפי מעלה.

---

## איך לשחק?
1.	לחץ והחזק את כפתור העכבר כדי להפעיל את הלהב.
2.	הזז את העכבר כדי לחתוך את האבטיחים.
3.	המשך לחתוך ולהתנסות במשחקיות הפשוטה והמהנה.








## קבצי הקוד

### 1. **`blade.cs`**
- קובץ זה אחראי על ניהול התנהגות החרב שאיתה חותכים את האבטיחים:
- מעקב אחרי תנועת העכבר.
- יצירת אפקט של מסלול החיתוך.
- זיהוי התנגשות עם אבטיחים כדי לבצע חיתוך.

#### קטע קוד לדוגמה הבודק שמהירות החיתוך מספיק גבוהה כדי לבצע חיתוך אבטיח:
```csharp
if (velocity > minCuttingVelocity)
{
    circleCollider.enabled = true;
}
else
{
    circleCollider.enabled = false;
}
```




### 2. **` fruit.cs`**

**קובץ זה מטפל בהתנהגות האבטיחים:**
-	האבטיחים משוגרים כלפי מעלה עם כוח התחלתי.
-	זיהוי חיתוך ויצירת שני חלקים של האבטיח שנעלמים לאחר זמן קצר.


**קטע קוד לדוגמה:**
קטע הקוד הזה מטפל באנימציית חיתוך האבטיח:
1.	מחליף את האבטיח המקורי באובייקט של אבטיח חצוי.
2.	האבטיח החצוי נשאר על המסך למשך 3 שניות לפני שהוא נעלם.
3.	האבטיח המקורי מושמד מידית לאחר החיתוך.

```csharp
GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);
Destroy(slicedFruit, 3f);
Destroy(gameObject);
```




### 3. **` spawnerScript.cs`**

•	קובץ זה אחראי על יצירת אבטיחים באופן אקראי:

o	האבטיחים נוצרים מתחת למסך ונזרקים כלפי מעלה.    
o	אבטיחים שלא נחתכו נעלמים לאחר זמן מוגדר.

**קטע קוד לדוגמה:**
קטע הקוד הזה מאפשר את היצירה של האבטיחים:

•קביעת זמן השהיה אקראי ליצירת האבטיח הבא.      
•  המתנה בהתאם לזמן האקראי שנבחר.   
•  יצירת אבטיח חדש במיקום ובזווית שנבחרו.   
•  מחיקת האבטיח שנוצר לאחר 5 שניות, אם השחקן לא חתך אותו.
```csharp
float delay = Random.Range(minDelay, maxDelay);
yield return new WaitForSeconds(delay);
GameObject spawnedFruit = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
Destroy(spawnedFruit, 5f);
________________________________________
