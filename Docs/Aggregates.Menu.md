# Domain Models

## Menu

```csharp
class Menu
{
  Menu Create();
  void AddDinner(Dinner dinner);
  void RemoveDinner(Dinner dinner);
  void UpdateSection(MenuSection section);
}
```

```json
{
  "id":"000000-0000-0000-0000-000000",
  "name": "Yummy Menu",
  "description": "A menu with yummy food",
  "averageRating": 4.5,
  "sections": [
    {
      "id": "000000-0000-0000-0000-000000",
      "name": "Appetizers",
      "description": "Starters",
      "items": [
        {
          "id": "000000-0000-0000-0000-000000",
          "name": "Fried Pickles",
          "description": "Deep fried pickles",
          "price": 5.99
        }
      ]
    }
  ],
  "createdAtDateTime": "",
  "updatedAtDateTime": "",
  "hostId":"000000-0000-0000-0000-000000",
  "dinnerIds": [
    "000000-0000-0000-0000-000000"
  ],
  "menuReviewIds": [
    "000000-0000-0000-0000-000000"
  ]
}
```