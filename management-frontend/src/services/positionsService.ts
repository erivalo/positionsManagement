import { Position } from '@/features/posts/PostsList';
import axios from 'axios';

const baseUrl = 'https://localhost:8001/api';

export const getPositions = async () => {
  try {
    const response = await axios.get(`${baseUrl}/positions`);
    return response.data;
  } catch (error) {
    console.log(error);
  }
  return [];
};

export const getPositionById = async (positionId: number) => {
  try {
    const response = await axios.get(`${baseUrl}/positions/${positionId}`);
    console.log(response);
    return response.data;
  } catch (error) {
    console.log(error);
  }
};

export const updatePosition = async (position: Position) => {
  try {
    await axios.put(`${baseUrl}/positions/${position.id}`, position);
  } catch (error) {
    console.log(error);
  }
};

export const createPosition = async (position: Position) => {
  try {
    await axios.post(`${baseUrl}/positions`, position);
  } catch (error) {
    console.log(error);
  }
};

export const deletePosition = async (positionId: number) => {
  try {
    await axios.delete(`${baseUrl}/positions/${positionId}`);
    return true;
  } catch (error) {
    console.log(error);
  }
};
