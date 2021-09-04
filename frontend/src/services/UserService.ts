export async function getAllUsers() {
  console.log("getAllUsers");
  const response = await fetch("/api/users");
  return await response.json();
}

export async function createUser(data: any) {
  console.log("creating user...", data);
  const response = await fetch(`/api/users`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  return await response.json();
}
