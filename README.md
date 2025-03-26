# positionsManagement

## Steps to run the app

At the same level of the docker-compose execute the sollowing commands in order

<ol>
  <li>docker compose up rabbitmq</li>
  <li>docker compose up management</li>
  <li>docker compose up frontend</li>
</ol>

## Steps to double check rabbitmq message

<ol>
  <li>Open the a browser and visit web page: http://localhost:5173, click on <em><strong>Add Position</strong></em> button, fill in the necessary data, then click on <em><strong>Create Position</strong></em></li>
  <li>Open the rabbitmq address on http://localhost:15672/, enter "guest" text as username, and password fields</li>
  <li>Click on <em><strong>Queues and Streams</strong></em> tab</li>
  <li>Click on <em><strong>PositionCreatedEvent</strong></em> under the column Name</li>
  <li>Then click on <em><strong>Get Messages</strong></em> sub menu</li>
  <li>Again click on <em><strong>Get Messages</strong></em> button</li>
  <li>The data should be similar to: <em><strong>{"positionId":"5","Id":"fd80062c-578f-4fb9-9ee7-8b9b21fef2ca","CreatedDate":"2025-03-26T19:34:45.1471212Z"}</strong></em></li>
</ol>
