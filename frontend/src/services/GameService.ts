import auth from "./AuthService";

export async function createGame(data: any) {
  const response = await fetch(`/api/games`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${auth.getToken()}`,
    },
    body: JSON.stringify(data),
  });
  return await response.json();
}

export async function getAllGames() {
  const response = await fetch(`/api/games`, {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${auth.getToken()}`,
    },
  });
  return await response.json();
}
