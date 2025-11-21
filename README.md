## pc2u202114643.API
### How to run
1. Restore dependencies: `dotnet restore`.
2. Update `appsettings.Development.json` with valid MySQL credentials (user/password) and make sure the `dfc` schema exists.
3. Run the API: `dotnet run`.
4. Use Swagger or the `pc2u202114643.API.http` file to test `POST /api/v1/dispatch-orders`.

### Author
- **Name:** u202114643
- **NRC:** 7454

pruebas

# Dispatch Orders – Test Suite
## POST /api/v1/dispatch-orders

Este documento contiene pruebas funcionales para validar el endpoint de creación de Dispatch Orders.

---

## 1. Test – Registro exitoso (201 Created)

### Request
```json
{
  "productId": "a3b1c7d2-7cb8-4f19-b18e-80caaf901111",
  "requestedUnits": 500,
  "dispatchExpectedAt": "2025-10-01T00:00:00",
  "dispatchCompletedAt": "2025-10-03T00:00:00",
  "notes": "Valid order"
}

Expected Result

Status: 201 Created

qualityLevel: Outstanding

dispatchDays: 2

Body example:

{
  "id": 1,
  "dispatchOrderId": "generated-guid",
  "productId": "a3b1c7d2-7cb8-4f19-b18e-80caaf901111",
  "requestedUnits": 500,
  "qualityLevel": "Outstanding",
  "dispatchCompletedAt": "2025-10-03T00:00:00",
  "dispatchDays": 2,
  "notes": "Valid order"
}


2. Test – requestedUnits menor a 100
Request
{
  "productId": "a3b1c7d2-7cb8-4f19-b18e-80caaf901111",
  "requestedUnits": 80,
  "dispatchExpectedAt": "2025-10-01T00:00:00",
  "dispatchCompletedAt": "2025-10-05T00:00:00"
}

Expected Result

Status: 400 Bad Request

{
  "error": "Requested units must be greater than 100."
}

3. Test – requestedUnits mayor a 5000
Request
{
  "productId": "a3b1c7d2-7cb8-4f19-b18e-80caaf901111",
  "requestedUnits": 9000,
  "dispatchExpectedAt": "2025-10-01T00:00:00",
  "dispatchCompletedAt": "2025-10-05T00:00:00"
}

Expected Result

Status: 400 Bad Request

{
  "error": "Requested units must be less or equal than 5000."
}

4. Test – dispatchExpectedAt no cumple regla (debe ser al menos 30 días antes de la fecha actual)
Request
{
  "productId": "a3b1c7d2-7cb8-4f19-b18e-80caaf901111",
  "requestedUnits": 500,
  "dispatchExpectedAt": "2025-11-01T00:00:00",
  "dispatchCompletedAt": "2025-11-10T00:00:00"
}

Expected Result

Status: 400 Bad Request

{
  "error": "Expected date must be at least 30 days before current date."
}

5. Test – dispatchCompletedAt menor que dispatchExpectedAt
Request
{
  "productId": "a3b1c7d2-7cb8-4f19-b18e-80caaf901111",
  "requestedUnits": 300,
  "dispatchExpectedAt": "2025-10-01T00:00:00",
  "dispatchCompletedAt": "2025-09-30T00:00:00"
}

Expected Result

Status: 400 Bad Request

{
  "error": "Completed date must be greater or equal than expected date."
}

6. Test – QualityLevel = Normal (más de 2 días)
Request
{
  "productId": "a3b1c7d2-7cb8-4f19-b18e-80caaf901111",
  "requestedUnits": 400,
  "dispatchExpectedAt": "2025-10-01T00:00:00",
  "dispatchCompletedAt": "2025-10-05T00:00:00"
}

Expected Result
{
  "qualityLevel": "Normal",
  "dispatchDays": 4
}

7. Test – QualityLevel = BellowExpected (más de 5 días)
Request
{
  "productId": "a3b1c7d2-7cb8-4f19-b18e-80caaf901111",
  "requestedUnits": 400,
  "dispatchExpectedAt": "2025-10-01T00:00:00",
  "dispatchCompletedAt": "2025-10-08T00:00:00"
}

Expected Result
{
  "qualityLevel": "BellowExpected",
  "dispatchDays": 7
}

8. Test – QualityLevel = Inefficient (más de 7 días)
Request
{
  "productId": "a3b1c7d2-7cb8-4f19-b18e-80caaf901111",
  "requestedUnits": 400,
  "dispatchExpectedAt": "2025-10-01T00:00:00",
  "dispatchCompletedAt": "2025-10-12T00:00:00"
}

Expected Result
{
  "qualityLevel": "Inefficient",
  "dispatchDays": 11
}

9. Test – ProductId vacío
Request
{
  "productId": "",
  "requestedUnits": 300,
  "dispatchExpectedAt": "2025-10-01T00:00:00",
  "dispatchCompletedAt": "2025-10-04T00:00:00"
}

Expected Result
{
  "error": "ProductId must be a valid GUID."
}

10. Test – ProductId faltante
Request
{
  "requestedUnits": 300,
  "dispatchExpectedAt": "2025-10-01T00:00:00",
  "dispatchCompletedAt": "2025-10-04T00:00:00"
}

Expected Result
{
  "error": "ProductId is required."
}
