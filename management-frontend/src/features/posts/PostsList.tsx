import { Link } from 'react-router-dom';
import { useEffect, useState } from 'react';
import { deletePosition, getPositions } from '@/services/positionsService';

export interface Position {
  id: number;
  title: string;
  budget: number;
  description: string;
  recruiterId: number;
  positionNumber: number;
  departmentId: number;
  statusId: number;
  status: string;
}

export const PostsList = () => {
  const [positions, setPositions] = useState<Position[]>([]);
  useEffect(() => {
    getPositions().then((positions) =>
      setPositions(positions as unknown as Position[])
    );
  }, []);

  const deleteHandler = async (positionId: number) => {
    const result = await deletePosition(positionId);
    if(!result) {
      return;
    }
    const newPositions = JSON.parse(JSON.stringify(positions)) as Position[];
    const filteredPositions = newPositions.filter(position => position.id !== positionId);
    setPositions(filteredPositions);
  }

  const renderedPosts = positions.map(position => (
    <article className='post-excerpt' key={position.id}>
      <h3><Link to={`/editPosition/${position.id}`}>{position.title}</Link></h3>
      <p className='post-content'>{position.description?.substring(0, 100)}</p>
      <button onClick={() => deleteHandler(position.id)}>Delete</button>
    </article>
  ));

  return (
    <section className='posts-list'>
      <h2>Positions</h2>
      {renderedPosts}
    </section>
  );
};
