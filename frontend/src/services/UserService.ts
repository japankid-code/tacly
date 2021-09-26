import auth from "./AuthService";

export async function getAllUsers() {
  const response = await fetch("/api/users", {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${auth.getToken()}`,
    },
  });
  return await response.json();
}

export async function getUserById(id: string) {
  const response = await fetch(`/api/users/id/${id}`, {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${auth.getToken()}`,
    },
  });
  return await response.json();
}

export async function getUserByUsername(inputUsername: string) {
  const response = await fetch(`/api/users/${inputUsername}`, {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${auth.getToken()}`,
    },
  });
  return await response.json();
}

export async function createUser(data: any) {
  const response = await fetch(`/api/users`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
  });
  return await response.json();
}

export async function loginUser(data: any) {
  const response = await fetch(`/api/userauth/login`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  return await response.json();
}

export async function addFriend(input: { userId: string; friendId: string }) {
  const response = await fetch(`/api/users/${input.userId}/${input.friendId}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${auth.getToken()}`,
    },
    body: JSON.stringify({}),
  });
  return await response.json();
}
