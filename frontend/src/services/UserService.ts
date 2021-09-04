export async function getAllUsers() {
  const response = await fetch("/api/users", {
    method: "GET",
    headers: { "Content-Type": "application/json" },
  });
  console.log("getAllUsers", response.body);
  return await response.json();
}

export async function createUser(data: any) {
  const response = await fetch(`/api/users`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  return await response.json();
}
