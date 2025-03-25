import { Link, useNavigate } from 'react-router-dom';
import { useEffect, useState } from 'react';
import { deletePosition, getPositions } from '@/services/positionsService';
import { option } from '@/utils/types';
import { recruiters } from '@/utils/constants';

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
  const [selectedRecruiterId, setSelectedRecruiterId] = useState<string>("0");
  const navigate = useNavigate();
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

  const renderedPosts = positions.filter(p => !Boolean(selectedRecruiterId) || p.recruiterId == parseInt(selectedRecruiterId)).map(position => (
    <article className='post-excerpt' key={position.id}>
      <h3><Link to={`/editPosition/${position.id}`}>{position.title}</Link></h3>
      <p className='post-content'>{position.description?.substring(0, 100)}</p>
      <button onClick={() => deleteHandler(position.id)}>Delete</button>
    </article>
  ));

  const handlerRecruiterFilter = (e: React.ChangeEvent<HTMLSelectElement>) => {
    e.preventDefault();
    setSelectedRecruiterId(e.target.value)
  }

  const addPositionHandler = () => {
    navigate(`/addPosition`);
  }

  const getOptions = (collection: option[]) => collection.map(element => (
    <option key={element.id} value={element.id}>
      {element.name}
    </option>
  ));

  const recruiterFilter = <select defaultValue={1} id="positionRecruiter" name="positionRecruiter" onChange={handlerRecruiterFilter} required>
    <option value="">Select...</option>
    {getOptions(recruiters)}
  </select>

  return (
    <section className='posts-list'>
      <h2>Positions</h2>
      <div>
        <div>
          <button onClick={addPositionHandler}>Add Position</button>
        </div>
        <div>
          {recruiterFilter}
        </div>
      </div>
      {renderedPosts}
    </section>
  );
};
