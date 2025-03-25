import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom"
import { createPosition, getPositionById, updatePosition } from "@/services/positionsService";
import { option } from "@/utils/types";
import { Position } from "./PostsList";
import { departments, recruiters, statuses } from "@/utils/constants";

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

export const EditPostForm = () => {  
  const { positionId } = useParams();
  const [position, setPosition] = useState<Position>();
  const navigate = useNavigate();

  useEffect(() => {
    if(!positionId)
    {
      return;
    }
    getPositionById(positionId ? parseInt(positionId) : 0)
      .then(position => setPosition(position));
  }, []);

  if(!position && positionId) {
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
    const statusId = parseInt(elements.positionStatus?.value);
    const positionToSend = {
      id: positionId ?? 0,
      title,
      positionNumber,
      budget,
      recruiterId,
      departmentId,
      statusId
    } as Position;
    positionId ?
      await updatePosition(positionToSend) :
      await createPosition(positionToSend);
    navigate(`/`);
  }

  const getOptions = (collection: option[]) => collection.map(element => (
    <option key={element.id} value={element.id}>
      {element.name}
    </option>
  ));

  const positionStatus = <>
    <label htmlFor="positionStatus">Position Status:</label>
    <select defaultValue={position?.statusId} id="positionStatus" name="positionStatus" required>
      <option value=""></option>
      {getOptions(statuses)}
    </select>
  </>;

  return (
    <section>
      <h2>{ positionId ? "Edit Position" : "Create Position"}</h2>
      <form onSubmit={onSavePossitionClicked}>
        <label htmlFor="positionTitle">Position Title:</label>
        <input
          type="text"
          id="positionTitle"
          defaultValue={position?.title}
          required
        />
        <label htmlFor="positionNumber">Position Number:</label>
        <input
          type="Number"
          id="positionNumber"
          defaultValue={position?.positionNumber}
          required
        />
        <label htmlFor="positionBudget">Position Budget:</label>
        <input
          type="Number"
          id="positionBudget"
          defaultValue={position?.budget}
          required
        />
        <label htmlFor="positionDepartment">Position Department:</label>
        <select defaultValue={position?.departmentId} id="positionDepartment" name="positionDepartment" required>
          <option value=""></option>
          {getOptions(departments)}
        </select>
        <label htmlFor="positionRecruiter">Position Recruiter:</label>
        <select defaultValue={position?.recruiterId} id="positionRecruiter" name="positionRecruiter" required>
          <option value=""></option>
          {getOptions(recruiters)}
        </select>
        {positionId ? positionStatus : null}
        <button>{positionId ? "Update Position" : "Create Position"}</button>
      </form>
    </section>
  )
}
