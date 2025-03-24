import { useParams, useNavigate } from "react-router-dom"
import { useEffect, useState } from "react";
import { getPositionById, updatePosition } from "@/services/positionsService";
import { Position } from "./PostsList";

interface EditPostFormFields extends HTMLFormControlsCollection {
  positionTitle: HTMLInputElement;
  positionNumber: HTMLInputElement;
  positionBudget: HTMLInputElement;
  positionDescription: HTMLTextAreaElement;
  positionRecruiter: HTMLOptionElement;
  positionDepartment: HTMLOptionElement;
  positionStatus: HTMLOptionElement;
}

interface EditPostFormElements extends HTMLFormElement {
  readonly elements: EditPostFormFields;
}

interface option {
  id: number;
  name: string;
}

const departments = [
  { id: 1, name: "Engeneering" },
  { id: 2, name: "Data" },
  { id: 3, name: "Operations" }
];

const recruiters = [
  { id: 1, name: "Maria" },
  { id: 2, name: "Juana" },
  { id: 3, name: "Cinthia" }
];

const statuses = [
  { id: 1, name: "Pending" },
  { id: 2, name: "Completed" },
  { id: 3, name: "Closed" }
];

export const EditPostForm = () => {  
  const { positionId } = useParams();
  const [position, setPosition] = useState<Position>();
  const navigate = useNavigate();

  useEffect(() => {
    getPositionById(positionId ? parseInt(positionId) : 0)
      .then(position => setPosition(position));
  }, []);

  if(!position) {
    return (
      <section>
        <h2>Position not found!</h2>
      </section>
    );
  }
  
  const onSavePossitionClicked = async (e: React.FormEvent<EditPostFormElements>) => {
    e.preventDefault();

    const { elements } = e.currentTarget;
    const title = elements.positionTitle.value;
    const positionNumber = parseInt(elements.positionNumber.value);
    const budget = parseInt(elements.positionBudget.value);
    const recruiterId = parseInt(elements.positionRecruiter.value);
    const departmentId = parseInt(elements.positionDepartment.value);
    const statusId = parseInt(elements.positionStatus.value);
    await updatePosition({ id: positionId ?? "", title, positionNumber, budget, recruiterId, departmentId, statusId } as Position);
    navigate(`/`);
  }

  const getOptions = (collection: option[]) => collection.map(element => (
    <option key={element.id} value={element.id}>
      {element.name}
    </option>
  ));

  return (
    <section>
      <h2>Edit Position</h2>
      <form onSubmit={onSavePossitionClicked}>
        <label htmlFor="positionTitle">Position Title:</label>
        <input
          type="text"
          id="positionTitle"
          defaultValue={position.title}
          required
        />
        <label htmlFor="positionNumber">Position Number:</label>
        <input
          type="Number"
          id="positionNumber"
          defaultValue={position.positionNumber}
          required
        />
        <label htmlFor="positionBudget">Position Budget:</label>
        <input
          type="Number"
          id="positionBudget"
          defaultValue={position.budget}
          required
        />
        <label htmlFor="positionDepartment">Position Department:</label>
        <select defaultValue={position.departmentId} id="positionDepartment" name="positionDepartment" required>
          <option value=""></option>
          {getOptions(departments)}
        </select>
        <label htmlFor="positionRecruiter">Position Recruiter:</label>
        <select defaultValue={position.recruiterId} id="positionRecruiter" name="positionRecruiter" required>
          <option value=""></option>
          {getOptions(recruiters)}
        </select>
        <label htmlFor="positionStatus">Position Status:</label>
        <select defaultValue={position.statusId} id="positionStatus" name="positionStatus" required>
          <option value=""></option>
          {getOptions(statuses)}
        </select>
        <button>Update Position</button>
      </form>
    </section>
  )
}
