import axios from 'axios';
const authToken = localStorage.getItem('token'); 

export async function insertUser({nombre, genero, atributos,maneja, lentes,diabetico, enfermedades }) {
  try {
      console.log("Enviando datos al servidor:", { nombre, genero, atributos,maneja, lentes,diabetico, enfermedades });
      const response = await axios.post('http://localhost:5000/api/users', 
          {nombre, genero, atributos,maneja, lentes,diabetico, enfermedades });
      console.log("Respuesta del servidor:", response);
      return response.data;
  } catch (error) {
      console.error('Error al crear users en Acciones.js:', error);
      throw error;
  }
}

export async function getUserById(userId) {
  try {
    console.log("este id estoy pasando: ", userId)
    const response = await axios.get(`http://localhost:5000/api/users/${userId}`);
    return response.data;
  } catch (error) {
    console.error('Error al obtener los users¡?:', error.response ? error.response.data : error.message);
    throw error;
  }
}

export async function updateUser(userId, { nombre, genero, atributos,maneja, lentes,diabetico, enfermedades }) {
  try {
    console.log("este id estoy pasando: ", userId,nombre,genero)
    const response = await axios.put(`http://localhost:5000/api/users/${userId}`, {nombre, genero, atributos,maneja, lentes,diabetico, enfermedades });
    
    return response.data;
  } catch (error) {
    console.error('Error al actualizar el users:', error);
    throw error;
  }
}

export async function getAllUsers() {
  try {
    const response = await axios.get('http://localhost:5000/api/users');
    console.log('users cargados:', response.data);
    return response.data;
  } catch (error) {
    console.error('Error al obtener los users:', error.response ? error.response.data : error.message);
    throw error;
  }
}


